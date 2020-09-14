using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosBEU.Transactions
{
	public class DetallePagoBLL
	{
		public static DetallePago Get(int? id)
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.DetallePago.Find(id);
		}

		public static void Create(DetallePago p)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.DetallePago.Add(p);
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

		public static void Update(DetallePago p)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.DetallePago.Attach(p);
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
						DetallePago p = db.DetallePago.Find(id);
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

		public static List<DetallePago> List()
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.DetallePago.ToList();
		}
	}
}
