using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
    class Prim
    {
        static int V;

        public Prim(List<RGBPixel> colorVerticies)
        {
            //V = colorVerticies.Count;
            MST(colorVerticies);
        }


        public static void MST(List<RGBPixel> colorVerticies)
        {
            V = colorVerticies.Count;
            int[] Nodes = new int[V];
            double[] Cost = new double[V];
            bool[] Visited = new bool[V];

            for (int v = 0; v < V; v++)
            {
                Cost[v] = 1e9;
                Visited[v] = false;
            }

            Cost[0] = 0;
            Nodes[0] = 0;

            for (int i = 0; i < V; i++)
            {
                double MinCost = 1e9;
                int index = 0;
                for (int j = 0; j < V; j++)
                {
                    if (Visited[j] == true && Cost[j] < MinCost)
                    {
                        MinCost = Cost[j];
                        index = j;
                    }
                }

                Visited[index] = true;

                for (int v = 0; v < V; v++)
                {
                    int R = colorVerticies[index].red - colorVerticies[v].red;
                    int G = colorVerticies[index].green - colorVerticies[v].green;
                    int B = colorVerticies[index].blue - colorVerticies[v].blue;

                    double EucledianDistance = Math.Sqrt(R * R + G * G + B * B);

                    if (EucledianDistance > 0 && Visited[v] == false && EucledianDistance < Cost[v])
                    {
                        Nodes[v] = index;
                        Cost[v] = EucledianDistance;
                    }
                }

                string file_name = "C:\\Users\\Rolla\\Desktop\\tree_test.txt";
                System.IO.StreamWriter objWriter;
                objWriter = new System.IO.StreamWriter(file_name);
                for(int r=0; r< V ; r++)
                {
                    objWriter.Write("(" + Nodes[i] + " " + Cost[i] + ")");
                }
                objWriter.Close();


            }

        }
    }
}
