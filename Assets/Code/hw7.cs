using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
    public  class hw7
    {
      int CountElem <T> (List<T> list,Type _type) => list.Count(predicate: i => i.GetType() == _type);

      int SymbolCount(string input) =>  input.Length;

    }
    
}