using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFrameWork
{
    public static class StaticMethods
    {
        public static string FormatStringInGroups(string input,int groupsize)
        {
            var stringResult=new StringBuilder();
            for(int i =0; i<input.Length;i++)
            {
                stringResult.Append(input[i]);

                if((i+1)% groupsize ==0 && i != input.Length-1)
                {
                    stringResult.Append('-');
                }
            }
            return stringResult.ToString();
        }
    }
}
