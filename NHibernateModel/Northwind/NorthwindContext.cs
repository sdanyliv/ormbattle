using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace OrmBattle.NHibernateModel.Northwind
{
  public class NorthwindContext : NHibernateContext
  {
    public NorthwindContext(ISession session)
      : base(session)
    {
    }

    public IOrderedQueryable<Category> Categories
    {
      get { return Session.Linq<Category>(); }
    }

    public IOrderedQueryable<Customer> Customers
    {
      get { return Session.Linq<Customer>(); }
    }

    public IOrderedQueryable<Employee> Employees
    {
      get { return Session.Linq<Employee>(); }
    }

    public IOrderedQueryable<Order> Orders
    {
      get { return Session.Linq<Order>(); }
    }

    public IOrderedQueryable<OrderDetail> OrderDetails
    {
      get { return Session.Linq<OrderDetail>(); }
    }

    public IOrderedQueryable<Product> Products
    {
      get { return Session.Linq<Product>(); }
    }

    public IOrderedQueryable<ActiveProduct> ActiveProducts
    {
      get { return Session.Linq<ActiveProduct>(); }
    }

    public IOrderedQueryable<DiscontinuedProduct> DiscontinuedProducts
    {
      get { return Session.Linq<DiscontinuedProduct>(); }
    }

    public IOrderedQueryable<Region> Regions
    {
      get { return Session.Linq<Region>(); }
    }

    public IOrderedQueryable<Shipper> Shippers
    {
      get { return Session.Linq<Shipper>(); }
    }

    public IOrderedQueryable<Supplier> Suppliers
    {
      get { return Session.Linq<Supplier>(); }
    }

    public IOrderedQueryable<Territory> Territories
    {
      get { return Session.Linq<Territory>(); }
    }
  }
}