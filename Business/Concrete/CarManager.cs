using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Business.Concrete
{
    public class CarManager :ICarService
    {
        ICarDal _carDal;
        ISubscribeService _subscribeService;
        IUserService _userService;
        public CarManager(ICarDal carDal, ISubscribeService subscribeService, IUserService userService)
        {
            _carDal = carDal;
            _subscribeService = subscribeService;
            _userService = userService;
        }
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            SendMail(car);

            return new SuccessResult();
        }

        

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.ColorId==colorId));
        }

        public IDataResult<Car> GetById(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetByUnitePrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.Price >= min && p.Price <= max ));

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
        private IDataResult<List<int>> CheckIfSubUserExists(Car car)
        {
            List<int> SubUsers = new List<int>();
            foreach (var item in _subscribeService.GetAll().Data)
            {
                if (item.SupUserId == car.UserId)
                {
                    SubUsers.Add(item.SubUserId);
                }

            }
            if (SubUsers.Count > 0)
            {
                return new SuccessDataResult<List<int>>(SubUsers);
            }
            return new ErrorDataResult<List<int>>();
        }
        private void SendMail(Car car)
        {
            if (CheckIfSubUserExists(car).Success)
            {
                User user = new User();
                List<string> SubUsersEmail = new List<string>();
                foreach (var userId in CheckIfSubUserExists(car).Data)
                {
                    user = _userService.GetById(userId).Data;
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("seenbilgi@outlook.com");
                        mail.To.Add(user.Email);
                        mail.Subject = $"{user.FirstName} Adlı kullanıcı yeni bir araba ekledi.";
                        mail.Body = $"{car.Km} {car.Year} {car.Description} Sadece {car.Price} TL";
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("seenbilgi@outlook.com", "123456789seen");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                }
            }
        }
    }
}
