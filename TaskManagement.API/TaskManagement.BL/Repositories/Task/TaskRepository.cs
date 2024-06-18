using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DataAccessLayer;

namespace TaskManagement.BL.Repositories.Task
{
    public class TaskRepository: ITaskRepository
    {
        private readonly DataContext _dataContext;
        public TaskRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
