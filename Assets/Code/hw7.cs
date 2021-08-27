using System;
using System.Collections.Generic;
using System.Linq;
namespace Code
{
    public class hw7
    {
        List<object> list = new List<object>();

        void CountElem(Type _type)
        {
           // var type = _type.GetType();
            int count = list.Count(predicate: i => i.GetType() == _type); //=> i is List<int>);
        }

        int SymbolCount(string input) 
        {
            int count = 0;
          foreach (char symbol in input) count++;
         
          return count;
          
         
        }
        
        
    }
}