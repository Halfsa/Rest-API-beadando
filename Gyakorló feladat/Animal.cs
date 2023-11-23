using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorló_feladat
{
	internal class Animal
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("Age")]
		public int Age { get; set; }
		[JsonProperty("Gender")]
		public string Gender { get; set; }
		[JsonProperty("species")]
		public string Species { get; set; }
		[JsonProperty("isAvailable")]
		public bool Available { get; set; }
	}
}
