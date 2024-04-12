﻿using TodoList.Models;

namespace TodoListBlazorWasm.Sevices
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList(TaskListSearch taskListSearch);

        Task<TaskDto> GetTaskDetail(string id);

        Task<bool> CreateTask(TaskCreateRequest request);
    }
}
