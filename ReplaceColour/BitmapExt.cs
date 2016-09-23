using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ReplaceColour
{
    public static class BitmapExt
    {
        public static void ChangeColour(Bitmap bmp, byte inColourR, byte inColourG, byte inColourB, byte outColourR, byte outColourG, byte outColourB)
        {
            // Specify a pixel format.

            PixelFormat pxf = PixelFormat.Format24bppRgb;

            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData =
            bmp.LockBits(rect, ImageLockMode.ReadWrite,
                         pxf);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap. 
            // int numBytes = bmp.Width * bmp.Height * 3; 
            int numBytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[numBytes];

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            // Manipulate the bitmap
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {
                if (rgbValues[counter] == inColourR &&
                    rgbValues[counter + 1] == inColourG &&
                    rgbValues[counter + 2] == inColourB)
                {
                    rgbValues[counter] = outColourR;
                    rgbValues[counter + 1] = outColourG;
                    rgbValues[counter + 2] = outColourB;
                }
            }

            // Copy the RGB values back to the bitmap
            Marshal.Copy(rgbValues, 0, ptr, numBytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);
        }


        public static void ChangeColour(Bitmap bmp, byte inColourR, byte inColourG, byte inColourB, byte outColourR, byte outColourG, byte outColourB, byte tol)
        {
            // Specify a pixel format.

            PixelFormat pxf = PixelFormat.Format24bppRgb;

            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData =
            bmp.LockBits(rect, ImageLockMode.ReadWrite,
                         pxf);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap. 
            // int numBytes = bmp.Width * bmp.Height * 3; 
            int numBytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[numBytes];

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            // Manipulate the bitmap
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {
                if (Math.Abs(rgbValues[counter] - inColourR) < tol &&
                    Math.Abs(rgbValues[counter + 1] - inColourG) < tol &&
                    Math.Abs(rgbValues[counter + 2] - inColourB) < tol)
                {
                    rgbValues[counter] = outColourR;
                    rgbValues[counter + 1] = outColourG;
                    rgbValues[counter + 2] = outColourB;
                }
            }

            // Copy the RGB values back to the bitmap
            Marshal.Copy(rgbValues, 0, ptr, numBytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);
        }


        public static void ChangeMonoColour(Bitmap bmp, byte tColourR, byte tColourG, byte tColourB, byte bColourR, byte bColourG, byte bColourB, byte tol)
        {
            // Specify a pixel format.

            PixelFormat pxf = PixelFormat.Format24bppRgb;

            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData =
            bmp.LockBits(rect, ImageLockMode.ReadWrite,
                         pxf);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap. 
            // int numBytes = bmp.Width * bmp.Height * 3; 
            int numBytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[numBytes];

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            // Manipulate the bitmap
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {
                if (Math.Abs(rgbValues[counter] - 0) <= tol &&
                    Math.Abs(rgbValues[counter + 1] - 0) <= tol &&
                    Math.Abs(rgbValues[counter + 2] - 0) <= tol)
                {

                    rgbValues[counter] = tColourR;
                    rgbValues[counter + 1] = tColourG;
                    rgbValues[counter + 2] = tColourB;
                }
                else
                {
                    rgbValues[counter] = bColourR;
                    rgbValues[counter + 1] = bColourG;
                    rgbValues[counter + 2] = bColourB;
                }
            }

            // Copy the RGB values back to the bitmap
            Marshal.Copy(rgbValues, 0, ptr, numBytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);
        }

        public static void ChangeAndScaleColour(Bitmap bmp, byte tColourR, byte tColourG, byte tColourB, byte bColourR, byte bColourG, byte bColourB)
        {
            // Specify a pixel format.

            PixelFormat pxf = PixelFormat.Format24bppRgb;

            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData =
            bmp.LockBits(rect, ImageLockMode.ReadWrite,
                         pxf);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap. 
            // int numBytes = bmp.Width * bmp.Height * 3; 
            int numBytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[numBytes];

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            // Manipulate the bitmap
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {
                string apa = "hej";
                if (rgbValues[counter] != 0)
                    if (rgbValues[counter] != 255)
                        apa = "apa";


                //double rgb1 = rgbValues[counter];

                //double facR = rgb1 / 255.0;
                double facR = GetScaleFac(rgbValues[counter]);
                byte newColR = ScaleColour(bColourR, tColourR, facR);

                double facG = GetScaleFac(rgbValues[counter + 1]);
                byte newColG = ScaleColour(bColourG, tColourG, facG);

                double facB = GetScaleFac(rgbValues[counter + 2]);
                byte newColB = ScaleColour(bColourB, tColourB, facB);

                rgbValues[counter] = newColR;
                rgbValues[counter + 1] = newColG;
                rgbValues[counter + 2] = newColB;


                //if (Math.Abs(rgbValues[counter] - 0) <= tol &&
                //    Math.Abs(rgbValues[counter + 1] - 0) <= tol &&
                //    Math.Abs(rgbValues[counter + 2] - 0) <= tol)
                //{

                //    rgbValues[counter] = tColourR;
                //    rgbValues[counter + 1] = tColourG;
                //    rgbValues[counter + 2] = tColourB;
                //}
                //else
                //{
                //    rgbValues[counter] = bColourR;
                //    rgbValues[counter + 1] = bColourG;
                //    rgbValues[counter + 2] = bColourB;
                //}
            }
            // Copy the RGB values back to the bitmap
            Marshal.Copy(rgbValues, 0, ptr, numBytes);
            // Unlock the bits.
            bmp.UnlockBits(bmpData);
        }

        private static double GetScaleFac(byte pix)
        {
            double rgb1 = pix;
            double facR = rgb1 / 255.0;
            facR = 1  - facR;
            return facR;
        }


        private static byte ScaleColour(byte background, byte text, double scale)
        {
            int diff = background - text;
            double newCol = Math.Round(background - diff * scale);

            byte output;
            if (byte.TryParse(newCol.ToString(), out output))
                return output;
            else
                throw new InvalidCastException("couldnt convert string to byte");
        }



    }
}
