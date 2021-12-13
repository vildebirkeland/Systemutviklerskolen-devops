import React, { useState, useEffect } from 'react';
import { TodoList } from './TodoList';
import { AddTodoForm } from './AddTodoForm';
import './App.css';

function App() {
  const [todos, setTodos] = useState<Todo[]>([]);

  const toggleTodo: ToggleTodo = (selectedTodo: Todo) => {
    const newTodos = todos.map((todo) => {
      if (todo === selectedTodo) {
        return {
          ...todo,
          complete: !todo.complete,
        };
      }
      return todo;
    });
    setTodos(newTodos);
  };

  useEffect(() => {
    fetch(window.location.origin + '/api/todo', {
      headers: new Headers({'accept': 'application/json'})
    })
      .then(response => response.json())
      .then(response => {
        setTodos(response);
      });
  }, []);

  const addTodo: AddTodo = (task: string) => {
    const newTodo = { task, id: undefined, complete: false };
    fetch(window.location.origin + '/api/todo', {
      method: 'post',
      body: JSON.stringify(newTodo),
      headers: new Headers({'content-type': 'application/json'})
    })
      .then(response => response.json())
      .then(response => {
        setTodos(response);
      });
  };

  return (
    <div className="app">
      <h1>Systemutviklerskolen todo-app</h1> 
      <TodoList todos={todos} toggleTodo={toggleTodo} />
      <AddTodoForm addTodo={addTodo} />
    </div>
  );
}

export default App;