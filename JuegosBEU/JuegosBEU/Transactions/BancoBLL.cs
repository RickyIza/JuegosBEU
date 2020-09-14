using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosBEU.Transactions
{
	public class BancoBLL
	{
		public static Banco Get(int? id)
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.Banco.Find(id);
		}

		public static void Create(Banco p)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Banco.Add(p);
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

		public static void Update(Banco p)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Banco.Attach(p);
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
						Banco p = db.Banco.Find(id);
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

		public static List<Banco> List()
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.Banco.ToList();
		}

		public static List<Banco> List(string criterio)
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.Banco.Where(x => x.numero_Cuenta.Contains(criterio)).ToList();
		}
	}
}
