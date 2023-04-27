using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFormService
    {
        void AddForm(Form form);
        void DeleteForm(Form form);
        void UpdateForm(Form form);
        List<Form> GetForms();
        Form GetById(int id);
    }
}
