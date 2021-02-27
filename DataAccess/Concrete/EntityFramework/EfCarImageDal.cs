using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, Context>, ICarImageDal
    {
        public void DeleteImage(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
        }

        public void Update(CarImage carImage)
        {
            using (Context context = new Context())
            {
                var result = Get(c => c.Id == carImage.Id);
                DeleteImage(result.ImagePath);
                carImage.Date = DateTime.Now;
                var updateEntity = context.Entry(carImage);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
