﻿using GenshinPray.Common;
using GenshinPray.Dao;
using GenshinPray.Models;
using GenshinPray.Models.DTO;
using GenshinPray.Models.PO;
using GenshinPray.Models.VO;
using GenshinPray.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenshinPray.Service
{
    public class MemberGoodsService : BaseService
    {
        private MemberGoodsDao memberGoodsDao;

        public MemberGoodsService()
        {
            this.memberGoodsDao = new MemberGoodsDao();
        }

        public void AddMemberGoods(YSPrayResult ySPrayResult, YSPondType pondType, int authId, string memberCode)
        {
            foreach (var result in ySPrayResult.PrayRecords)
            {
                //if (result.GoodsItem.RareType != YSRareType.四星 && result.GoodsItem.RareType != YSRareType.五星) continue;
                MemberGoodsPO memberGoods = new MemberGoodsPO();
                memberGoods.AuthId = authId;
                memberGoods.GoodsName = result.GoodsItem.GoodsName;
                memberGoods.PondType = pondType;
                memberGoods.GoodsType = result.GoodsItem.GoodsType;
                memberGoods.GoodsSubType = result.GoodsItem.GoodsSubType;
                memberGoods.RareType = result.GoodsItem.RareType;
                memberGoods.MemberCode = memberCode;
                memberGoods.CreateDate = DateTime.Now;
                memberGoodsDao.Insert(memberGoods);
            }
        }

        public MemberGoodsCountDTO GetMemberGoodsCount(int authId, string memberCode)
        {
            MemberGoodsCountDTO memberGoodsCount = new MemberGoodsCountDTO();
            memberGoodsCount.Star4Count = memberGoodsDao.CountByMember(authId, memberCode, YSRareType.四星);
            memberGoodsCount.Star5Count = memberGoodsDao.CountByMember(authId, memberCode, YSRareType.五星);
            memberGoodsCount.RoleStar4Count = memberGoodsDao.CountByMember(authId, memberCode, YSPondType.角色, YSRareType.四星);
            memberGoodsCount.ArmStar4Count = memberGoodsDao.CountByMember(authId, memberCode, YSPondType.武器, YSRareType.四星);
            memberGoodsCount.PermStar4Count = memberGoodsDao.CountByMember(authId, memberCode, YSPondType.常驻, YSRareType.四星);
            memberGoodsCount.RoleStar5Count = memberGoodsDao.CountByMember(authId, memberCode, YSPondType.角色, YSRareType.五星);
            memberGoodsCount.ArmStar5Count = memberGoodsDao.CountByMember(authId, memberCode, YSPondType.武器, YSRareType.五星);
            memberGoodsCount.PermStar5Count = memberGoodsDao.CountByMember(authId, memberCode, YSPondType.常驻, YSRareType.五星);
            return memberGoodsCount;
        }

        public LuckRankingVO getLuckRanking(int authId, int days, int top)
        {
            LuckRankingVO luckRankingCache = DataCache.GetLuckRankingCache(authId);
            if (luckRankingCache != null) return luckRankingCache;
            DateTime startDate = DateTime.Now.AddDays(-1 * days);
            DateTime endDate = DateTime.Now;
            List<LuckRankingDTO> star5RankingList = memberGoodsDao.getLuckRanking(authId, top, YSRareType.五星, startDate, endDate);
            List<LuckRankingDTO> star4RankingList = memberGoodsDao.getLuckRanking(authId, top, YSRareType.四星, startDate, endDate);
            LuckRankingVO luckRankingVO = new LuckRankingVO();
            luckRankingVO.Top = top;
            luckRankingVO.StartDate = startDate;
            luckRankingVO.EndDate = endDate;
            luckRankingVO.Star5Ranking = star5RankingList.Select(m => toRareRanking(m)).ToList();
            luckRankingVO.Star4Ranking = star4RankingList.Select(m => toRareRanking(m)).ToList();
            DataCache.SetLuckRankingCache(authId, luckRankingVO);
            return luckRankingVO;
        }

        private RareRankingVO toRareRanking(LuckRankingDTO luckRankingDTO)
        {
            RareRankingVO rareRankingVO = new RareRankingVO();
            rareRankingVO.TotalPrayTimes = luckRankingDTO.TotalPrayTimes;
            rareRankingVO.MemberCode = luckRankingDTO.MemberCode;
            rareRankingVO.Count = luckRankingDTO.RareCount;
            rareRankingVO.Rate = Math.Floor(luckRankingDTO.RareRate * 100 * 1000) / 1000;
            return rareRankingVO;
        }


    }
}
