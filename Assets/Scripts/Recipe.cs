//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace AssemblyCSharp
{
	public class Recipe
	{
		Item part1, part2;
		Item result;
		public Recipe ()
		{
			
		}

		public Recipe(Item a, Item b, Item c) {
			part1 = a;
			part2 = b;
			result = c;
		}

		public Item craftIt(Item a, Item b) {
			if (a == part1 && b == part2) {
				return result;	
			} else {
				return a;
			}
		}
	}
}

