using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace Gyakorló_feladat
{
	//https://retoolapi.dev/0oPTIa/animals
	internal class Animals
	{
		HttpClient client = new HttpClient();
		string link = "https://retoolapi.dev/0oPTIa/animals";

		public List<Animal> GetAnimals()
		{
			string json = client.GetStringAsync(link).Result;
			return JsonConvert.DeserializeObject<List<Animal>>(json);
		}
		public Animal Adopt(int id, Animal animal)
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(animal), Encoding.UTF8, "application/json");
			HttpResponseMessage responseMessage = client.PatchAsync($"{link}/{id}", content).Result;

			string responseContent = responseMessage.Content.ReadAsStringAsync().Result;
			return JsonConvert.DeserializeObject<Animal>(responseContent);
		}
		public bool PutDown(Animal animal)
		{
			int id = animal.Id;
			HttpResponseMessage reponse = client.DeleteAsync($"{link}/{id}").Result;
			if (reponse.IsSuccessStatusCode)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
