using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceColour
{
    public static class SignColours
    {
        public static class WhiteBlack
        {
            public static string Name = "WhiteBlack";
            public static byte[] Text = { 0, 0, 0};
            public static byte[] Background = { 255, 255, 255 };
        }

        public static class RedWhite
        {
            public static string Name = "RedWhite";
            //public static byte[] Background = { 0, 0, 255 };
            public static byte[] Background = { 255, 0, 0 };
            public static byte[] Text = { 255, 255, 255 };
        }

        public static class YellowBlack
        {
            public static string Name = "YellowBlack";
            public static byte[] Background = { 255, 255, 0 };
            public static byte[] Text = { 0, 0, 0 };
        }

        public static class GreenWhite
        {
            public static string Name = "GreenWhite";
            public static byte[] Background = { 0, 128, 0 };
            public static byte[] Text = { 255, 255, 255 };
        }

        public static class BlackWhite
        {
            public static string Name = "BlackWhite";
            public static byte[] Background = { 0, 0, 0 };
            public static byte[] Text = { 255, 255, 255 };
        }

        public static class BlueWhite
        {
            public static string Name = "BlueWhite";
            public static byte[] Background = { 40, 40, 255 };
            public static byte[] Text = { 255, 255, 255 }; 
        }

        public static class SilverBlack
        {
            public static string Name = "SilverBlack";
            public static byte[] Background = { 176, 176, 176 };
            public static byte[] Text = { 0, 0, 0 };
        }

        public static class GoldBlack
        {
            public static string Name = "GoldBlack";
            public static byte[] Background = { 192, 192, 0 };
            public static byte[] Text = { 0, 0, 0 };
        }

        public static class BrownWhite
        {
            public static string Name = "BrownWhite";
            public static byte[] Background = { 125, 87, 83 };
            public static byte[] Text = { 255, 255, 255 };
        }

        public static class OrangeWhite
        {
            public static string Name = "OrangeWhite";
            public static byte[] Background = { 253, 119, 19 };
            public static byte[] Text = { 255, 255, 255 };
        }

        public static class WhiteRed
        {
            public static string Name = "WhiteRed";
            //public static byte[] Background = { 0, 0, 255 };
            public static byte[] Background = { 255, 255, 255 };
            public static byte[] Text = { 0, 0, 255 };
        }

        public static class YellowRed
        {
            public static string Name = "YellowRed";
            //public static byte[] Background = { 0, 0, 255 };
            public static byte[] Background = { 255, 255, 0 };
            public static byte[] Text = { 0, 0, 255 };
        }

        public static class GreenBlack
        {
            public static string Name = "GreenBlack";
            public static byte[] Background = { 0, 107, 37 };
            public static byte[] Text = { 0, 0, 0 };
        }

        public static class BlueBlack
        {
            public static string Name = "BlueBlack";
            public static byte[] Background = { 40, 40, 200 };
            public static byte[] Text = { 0, 0, 0 };
        }

        public static class RedBlack
        {
            public static string Name = "RedBlack";
            public static byte[] Background = { 130, 1, 1 };
            public static byte[] Text = { 0, 0, 0 };
        }

        public static class GreyWhite
        {
            public static string Name = "GreyWhite";
            public static byte[] Background = { 128, 128, 128 };
            public static byte[] Text = { 255, 255, 255 };
        }

        public static class WhiteBlue
        {
            public static string Name = "WhiteBlue";
            public static byte[] Background = { 255, 255, 255 };
            public static byte[] Text = { 128, 0, 0 };
        }
    
        public static class Random
        {
            public static byte[] Background = { 22, 213, 119 };
        }




    }
}
