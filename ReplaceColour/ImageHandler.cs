using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ReplaceColour
{
    public class ImageHandler
    {
        //private List<ColourParam> _colourParams;
        private List<Sign> _signs;
        private List<string> _srcImageList;
        private string _srcImage;
        private Bitmap _bmp;
        private List<Bitmap> _bmpList;


        public ImageHandler()
        {
            InitialiseImageHandler();
        }

        public void InitialiseImageHandler()
        {
            _srcImageList = new List<string>();
            _bmpList = new List<Bitmap>();
            _signs = new List<Sign>();
        }


        public void ClearBitmapList()
        {
            _srcImageList.Clear();
            _bmpList.Clear();
        }

        public void RegisterBitmapSource(string path)
        {
            _srcImageList.Add(path);
        }


        public void ClearSignColourList()
        {
            _signs.Clear();
        }
        public void CreateSign(byte[] bgrRGB, byte[] txtRGB, string name)
        {
            Sign sign = new Sign();
            sign.Name = name;

            ColourParam txtParam = new ColourParam();
            txtParam.InR = 0;
            txtParam.InG = 0;
            txtParam.InB= 0;
            txtParam.OutR = txtRGB[0];
            txtParam.OutG = txtRGB[1];
            txtParam.OutB = txtRGB[2];
            sign.TextColour = txtParam;

            ColourParam bgrParam = new ColourParam();
            bgrParam.InR = 255;
            bgrParam.InG = 255;
            bgrParam.InB = 255;
            bgrParam.OutR = bgrRGB[0];
            bgrParam.OutG = bgrRGB[1];
            bgrParam.OutB = bgrRGB[2];
            sign.BackgoundColour = bgrParam;

            _signs.Add(sign);
        }


        public void LoadImage(string path) 
        {
            _srcImage = path;
            _bmp = new Bitmap(path);
        }

        public void LoadImages()
        {
            _bmpList.Clear();

            foreach (string path in _srcImageList)
            {
                try
                {
                    Bitmap bmp = new Bitmap(path);
                    _bmpList.Add(bmp);
                }
                catch
                {
                    throw new InvalidFileException("File format is invalid for the path " + path);
                    //throw new Exception("File format is invalid for the path " + path);
                }
            }

        }


        public void Reset()
        {
            InitialiseImageHandler();
        }

        public void Run()
        {
            //Reset();

            try
            {
                LoadImages();
            }
            catch(Exception e)
            {
                throw e;   
            }  

            int i = 0;
            foreach (Bitmap bitmap in _bmpList)
            {
                foreach (Sign sign in _signs)
                {
                    Bitmap bitmapCopy = (Bitmap)bitmap.Clone();

                    string path = _srcImageList[i];
                    ReplaceColourOnImage(bitmapCopy, sign);
                    SaveBitmap(bitmapCopy, sign, path);
                }
                i++;
            }
        }

        public void ReplaceColourOnImage(Bitmap bitmap, Sign sign)
        {
            byte tol = 80;

            BitmapExt.ChangeAndScaleColour(bitmap,
                sign.TextColour.OutR,
                sign.TextColour.OutG,
                sign.TextColour.OutB,
                sign.BackgoundColour.OutB,
                sign.BackgoundColour.OutG,
                sign.BackgoundColour.OutR);
            return;


            BitmapExt.ChangeMonoColour(bitmap,
                sign.TextColour.OutR,
                sign.TextColour.OutG,
                sign.TextColour.OutB,
                sign.BackgoundColour.OutB,
                sign.BackgoundColour.OutG,
                sign.BackgoundColour.OutR, 0);




            ////change to random colour to make sure no wrong replacements occur
            BitmapExt.ChangeColour(bitmap, sign.BackgoundColour.InR,
                sign.BackgoundColour.InG,
                sign.BackgoundColour.InB,
                SignColours.Random.Background[0],
                SignColours.Random.Background[1],
                SignColours.Random.Background[2], tol);

            //change text
            BitmapExt.ChangeColour(bitmap,
                sign.TextColour.InR,
                sign.TextColour.InG,
                sign.TextColour.InB,
                sign.TextColour.OutR,
                sign.TextColour.OutG,
                sign.TextColour.OutB, tol);


                        BitmapExt.ChangeColour(bitmap,
                SignColours.Random.Background[0],
                SignColours.Random.Background[1],
                SignColours.Random.Background[2],
                sign.BackgoundColour.OutB,
                sign.BackgoundColour.OutG,
                sign.BackgoundColour.OutR, tol);


        }

        public void SaveBitmap(Bitmap bitmap, Sign sign, string src)
        {
            string path, filename;
            DecomposePath(src, out path, out filename);
            bitmap.Save(path + "_" + sign.Name + filename);
        }

        private void DecomposePath(string src, out string path, out string filename)
        {
            int idx = src.LastIndexOf('.');
            path = src.Substring(0, idx);
            filename = src.Substring(idx, src.Length - idx);
        }

    }


    

}
