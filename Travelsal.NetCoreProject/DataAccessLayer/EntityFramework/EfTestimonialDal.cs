﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfTestimonialDal : GenericRepository<Testimonial>,ITestimonialDal
	{
	}
}