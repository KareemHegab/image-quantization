using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
    class DistinctColours
    {
        public List<RGBPixel> DistinctColoursList;
        public DistinctColours(RGBPixel[,] ImageMatrix)
        {
            DistinctColoursList = new List<RGBPixel>();
            getDistinct(ImageMatrix);

        }

        /// <summary>
        /// Extracts the Distinct Colours from the image
        /// <param name="ImageMatrix">Colored image matrix</param>
        /// <returns>List of all the distinct colours </returns>
        /// </summary>
        private void getDistinct(RGBPixel[,] ImageMatrix)
        {
            bool[,,] flagColour = new bool[256, 256, 256];

            int w = ImageOperations.GetWidth(ImageMatrix), h = ImageOperations.GetHeight(ImageMatrix), cnt = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    byte r = ImageMatrix[i, j].red, g = ImageMatrix[i, j].green, b = ImageMatrix[i, j].blue;
                    if (flagColour[r,g,b] == false)
                    {
                        flagColour[r, g, b] = true;
                        DistinctColoursList.Add(new RGBPixel(r, g, b));
                    }
                    
                }
            }
        }

    }
}
