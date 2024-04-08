﻿using Task= TodoList.Api.Entitier.Task;

namespace TodoList.Api.Repositories
{
   public  interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetTasksList();

        Task<Task> Delete(Task task);

        Task<Task> Update(Task task);

        Task<Task> Create(Task task);

        Task<Task> GetByID(Guid id);

    }
}
