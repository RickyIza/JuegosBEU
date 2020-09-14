using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosBEU.Transactions
{
	public class JuegoBLL
	{
		public static Juego Get(int? id)
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.Juego.Find(id);
		}

		public static void Create(Juego p)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Juego.Add(p);
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
			}
		}

		public static void Update(Juego p)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Juego.Attach(p);
						db.Entry(p).State = System.Data.Entity.EntityState.Modified;
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
			}
		}

		public static void Delete(int? id)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						Juego p = db.Juego.Find(id);
						db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
			}
		}

		public static List<Juego> List()
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.Juego.ToList();
		}

		public static List<Juego> List(string criterio)
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.Juego.Where(x => x.estado.Contains(criterio)).ToList();
		}
	}
}
