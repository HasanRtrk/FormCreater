using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FormManager : IFormService
    {
        IFormDal _formDal;
        public FormManager(IFormDal formDal)
        {
            _formDal = formDal;
        }

        public void AddForm(Form form)
        {
            _formDal.Add(form);
        }

        public void DeleteForm(Form form)
        {
            _formDal.Delete(form);
        }

        public Form GetById(int id)
        {
           return _formDal.GetById(id);
        }

        public List<Form> GetForms()
        {
            return _formDal.GetList();
        }

        public void UpdateForm(Form form)
        {
            _formDal.Update(form);
        }
    }
}
