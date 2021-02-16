﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);

                foreach (var item in result)
                {
                    if (item.ReturnDate == null)
                    {
                        return new ErrorResult();
                    }
                }
           
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Add(rental);

            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult();
        }
    }
}
