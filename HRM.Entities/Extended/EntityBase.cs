using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace HRM.Entities
{
    public partial class EntityBase
    {
        private int _Id;

        public EntityBase()
        {            
            
        }

        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

      
    }
}
