using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static enumer.MojaLista;

namespace enumer
{
	class Program
	{
		static void Main(string[] args)
		{
			/*foreach (int br in Foo(15))
				Console.WriteLine(br);

			Console.WriteLine($"Broj na 6om mestu je: {Foo(20).ToList()[5]}");


			using (var en = Foo(10).GetEnumerator())
			{
				Console.WriteLine("---------------------------");
				//Console.WriteLine(en.Current);
				//en.MoveNext();
				//en.MoveNext();
				Console.WriteLine(en.Current);
				Console.WriteLine("---------------------------");

				while (en.MoveNext())
				{
					Console.WriteLine(en.Current);
				}
			}

			Console.ReadKey();
		}

		static IEnumerable<int> Foo(int duzina)
		{
			int pposlednji, poslednji, trenutni;
			pposlednji = poslednji = trenutni = 0;

			if (duzina <= 0)
				throw new ArgumentOutOfRangeException("Samo pozitivno ;)");
			do
			{
				yield return trenutni;

				trenutni = (poslednji + pposlednji) switch
				{
					0 => 1,
					_ => poslednji + pposlednji
				};

				/*switch (pposlednji + poslednji)
				{
					case 0:
						trenutni = 1;
						break;
					default:
						trenutni = pposlednji + poslednji;
						break;
				}
				pposlednji = poslednji;
				poslednji = trenutni;
			} while (--duzina > 0);*/

			MojaLista ml = new MojaLista();

			foreach (var n in ml)
				Console.WriteLine(n);
			Console.WriteLine("---------------------------");
			ml.Dodaj("asd");
			ml.Dodaj("zxc");
			using (var en = ml.GetEnumerator() as MojEnumerator)
			{
				while (en.MoveNext())
				{
					Console.WriteLine(en.Current);
					//if (en.Current == "C")
					//	en.Reset();
				}
				Console.WriteLine("**************************");
				while (en.MoveBack())
				{
					Console.WriteLine(en.Current);
				}
			}
			Console.ReadLine();
		}
	}

	class MojaLista : IEnumerable<string>
	{
		string[] Niz = { "A", "B", "C" };

		public void Dodaj(string s)
		{
			Array.Resize<string>(ref Niz, Niz.Length + 1);
			Niz[Niz.Length - 1] = s;
		}

		public IEnumerator<string> GetEnumerator()
			=> new MojEnumerator(Niz);
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			=> GetEnumerator();

		public class MojEnumerator : IEnumerator<string>
		{
			public string Current
				=> indeks < 0 && indeks < Kolekcija.Length ? 
					throw new IndexOutOfRangeException("Puce :/") : Kolekcija[indeks];
			
			object IEnumerator.Current => Current;

			private int indeks = -1;
			private string[] Kolekcija;
			public MojEnumerator(string[] kol)
			{
				Kolekcija = kol;
			}

			public void Dispose(){}
			private int dooosta = 0;
			public bool MoveNext()
			{
				if (dooosta < 10)
				{
					if (++indeks >= Kolekcija.Length)
						indeks = 0;
					dooosta++;
					return true;
				}
				else
					return false;
			}

			public bool MoveBack()
				=> --indeks >= 0;

			public void Reset()
			{
				indeks = -1;
			}
		}
		
	}
}
