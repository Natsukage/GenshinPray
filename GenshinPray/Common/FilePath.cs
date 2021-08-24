﻿using GenshinPray.Models;
using GenshinPray.Type;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GenshinPray.Common
{
    public static class FilePath
    {

        /// <summary>
        /// 原神祈愿素材目录
        /// </summary>
        private static string ImageDirPath = "~/PrayMaterial/";

        /// <summary>
        /// 获取模拟抽卡图片保存的绝对路径
        /// </summary>
        /// <returns></returns>
        public static string getPrayImgSavePath()
        {
            string path = ImageDirPath + "pray\\";
            if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
            return path;
        }

        /// <summary>
        /// 背景图路径
        /// </summary>
        /// <returns></returns>
        public static string getYSPrayBGPath()
        {
            return ImageDirPath + "背景\\背景.png";
        }

        /// <summary>
        /// 框路径
        /// </summary>
        /// <returns></returns>
        public static string getYSFrameImgPath()
        {
            return ImageDirPath + "框\\框.png";
        }

        /// <summary>
        /// 星星路径
        /// </summary>
        /// <returns></returns>
        public static string getYSProspectImgPath()
        {
            return ImageDirPath + "框\\星星.png";
        }

        /// <summary>
        /// 角色小图路径
        /// </summary>
        /// <param name="goodsItem"></param>
        /// <returns></returns>
        public static string getYSSmallRoleImgPath(YSGoodsItem goodsItem)
        {
            return ImageDirPath + $"角色小图\\{goodsItem.GoodsName}.png";
        }

        /// <summary>
        /// 武器大图路径
        /// </summary>
        /// <param name="goodsItem"></param>
        /// <returns></returns>
        public static string getYSEquipImgPath(YSGoodsItem goodsItem)
        {
            return ImageDirPath + $"武器\\{goodsItem.GoodsName}.png";
        }

        /// <summary>
        /// 光效图片路径
        /// </summary>
        /// <param name="goodsItem"></param>
        /// <returns></returns>
        public static string getYSLightPath(YSGoodsItem goodsItem)
        {
            if (goodsItem.RareType == YSRareType.五星) return ImageDirPath + "框\\金光.png";
            if (goodsItem.RareType == YSRareType.四星) return ImageDirPath + "框\\紫光.png";
            if (goodsItem.RareType == YSRareType.三星) return ImageDirPath + "框\\蓝光.png";
            return ImageDirPath + "框\\蓝光.png";
        }

        /// <summary>
        /// 星星路径
        /// </summary>
        /// <returns></returns>
        public static string getYSStarPath()
        {
            return ImageDirPath + "图标\\星星.png";
        }

        /// <summary>
        /// 透明元素图标路径
        /// </summary>
        /// <param name="goodsItem"></param>
        /// <returns></returns>
        public static string getYSBigElementIconPath(YSGoodsItem goodsItem)
        {
            return ImageDirPath + $"元素图标大\\{Enum.GetName(typeof(YSGoodsType), goodsItem.GoodsType)}.png";
        }

        /// <summary>
        /// 彩色元素图标路径
        /// </summary>
        /// <param name="goodsItem"></param>
        /// <returns></returns>
        public static string getYSSmallElementIconPath(YSGoodsItem goodsItem)
        {
            return ImageDirPath + $"元素图标小\\{Enum.GetName(typeof(YSGoodsType), goodsItem.GoodsType)}.png";
        }

        /// <summary>
        /// 白色武器图标路径
        /// </summary>
        /// <param name="goodsItem"></param>
        /// <returns></returns>
        public static string getYSWhiteEquipIconPath(YSGoodsItem goodsItem)
        {
            return ImageDirPath + $"武器图标白\\{Enum.GetName(typeof(YSGoodsType), goodsItem.GoodsType)}.png";
        }

        /// <summary>
        /// 灰色武器图标路径
        /// </summary>
        /// <param name="goodsItem"></param>
        /// <returns></returns>
        public static string getYSBlackEquipIconPath(YSGoodsItem goodsItem)
        {
            return ImageDirPath + $"武器图标黑\\{Enum.GetName(typeof(YSGoodsType), goodsItem.GoodsType)}.png";
        }

        /// <summary>
        /// 关闭图标路径
        /// </summary>
        /// <returns></returns>
        public static string getYSCloseIconPath()
        {
            return ImageDirPath + "图标\\关闭.png";
        }

        /// <summary>
        /// 角色大图路径
        /// </summary>
        /// <param name="goodsItem"></param>
        /// <returns></returns>
        public static string getYSBigRoleImgPath(YSGoodsItem goodsItem)
        {
            return ImageDirPath + $"角色大图\\{goodsItem.GoodsName}.png";
        }

        /// <summary>
        /// 单抽中的武器背景图片路径
        /// </summary>
        /// <param name="goodsItem"></param>
        /// <returns></returns>
        public static string getYSEquipBgPath(YSGoodsItem goodsItem)
        {
            return ImageDirPath + $"武器背景\\{Enum.GetName(typeof(YSGoodsType), goodsItem.GoodsType)}.png";
        }

        /// <summary>
        /// 代币图标路径
        /// </summary>
        /// <param name="goodsItem"></param>
        /// <returns></returns>
        public static string getYSTokenPath(YSGoodsItem goodsItem)
        {
            if (goodsItem.RareType == YSRareType.三星) return ImageDirPath + "框\\无主的星尘15.png";
            if (goodsItem.RareType == YSRareType.四星) return ImageDirPath + "框\\无主的星辉02.png";
            if (goodsItem.RareType == YSRareType.五星) return ImageDirPath + "框\\无主的星辉10.png";
            throw new Exception($"找不到与{Enum.GetName(typeof(YSRareType), goodsItem.RareType)}对应的代币");
        }

        /// <summary>
        /// 泡泡路径
        /// </summary>
        /// <returns></returns>
        public static List<string> getBubblesBigPathList()
        {
            return new List<string>()
            {
                ImageDirPath + "泡泡\\蓝色10.png",
                ImageDirPath + "泡泡\\紫色10.png",
                ImageDirPath + "泡泡\\蓝色05.png",
                ImageDirPath + "泡泡\\紫色05.png"
            };
        }

        /// <summary>
        /// 泡泡路径
        /// </summary>
        /// <returns></returns>
        public static List<string> getBubblesSmallPathList()
        {
            return new List<string>()
            {
                ImageDirPath + "泡泡\\蓝色50.png",
                ImageDirPath + "泡泡\\紫色50.png",
                ImageDirPath + "泡泡\\蓝色25.png",
                ImageDirPath + "泡泡\\紫色25.png"
            };
        }


    }
}
