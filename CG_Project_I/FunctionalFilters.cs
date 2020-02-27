﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace CG_Project_I
{
    class FunctionalFilters
    {
        public FunctionalFilters() { }

        //https://www.codeproject.com/Articles/23323/A-Generic-Clamp-Function-for-C
        public static int Clamp(int value)
        {
            int result = value;
            if (value.CompareTo(255) > 0)
                result = 255;
            if (value.CompareTo(0) < 0)
                result = 0;
            return result;
        }

        public Bitmap inversion(Bitmap img) {
            for (int y = 0; y < img.Height ; y++)
            {
                for (int x = 0; x < img.Width ; x++)
                {
                    Color tmp = img.GetPixel(x, y);
                    tmp = Color.FromArgb((255 - tmp.R), (255 - tmp.G), (255 - tmp.B));
                    img.SetPixel(x, y, tmp);
                }
            }
            return img;
        }

        public Bitmap brightness(Bitmap img, int step)
        {
            for (int y = 0; y < img.Height ; y++)
            {
                for (int x = 0; x < img.Width ; x++)
                {
                    Color tmp = img.GetPixel(x, y);
                    tmp = Color.FromArgb(Clamp(tmp.R + step), Clamp(tmp.G + step), Clamp(tmp.B + step));
                    img.SetPixel(x, y, tmp);
                }
            }
            return img;
        }

        public Bitmap contrast(Bitmap img, double step)
        {
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    var tmp = img.GetPixel(x, y);
                    int red = (int)((tmp.R - 127.5) * step);
                    int green = (int)((tmp.G - 127.5) * step);
                    int blue = (int)((tmp.B - 127.5) * step);

                    tmp = Color.FromArgb(Clamp(red), Clamp(green), Clamp(blue));
                    img.SetPixel(x, y, tmp);
                }
            }
            return img;
        }

        public Bitmap gamma(Bitmap img, double step)
        {
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    var tmp = img.GetPixel(x, y);
                    int red = (int)Math.Pow(tmp.R,step);
                    int green = (int)Math.Pow(tmp.G, step);
                    int blue = (int)Math.Pow(tmp.B, step);


                    var newColor = Color.FromArgb(Clamp(red), Clamp(green), Clamp(blue));
                    img.SetPixel(x, y, newColor);
                }
            }
            return img;
        }
    }
}
