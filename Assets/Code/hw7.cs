using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
    public  class hw7
    {
      int CountElem <T> (List<T> list,Type _type) => list.Count(predicate: i => i.GetType() == _type);

      int SymbolCount(string input) =>  input.Length;

      Dictionary<string, int> dict = new Dictionary<string, int>()
      {
          {"four",4 },
          {"two",2 },
          { "one",1 },
          {"three",3 },
      };

      void DoIT()
      {
          var d = dict.OrderBy(pair => pair.Value);
          //dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });
          foreach (var pair in d)
      {
          Debug.Log($"{pair.Key} - {pair.Value}");
      }
      }
      
      
    }
    
}