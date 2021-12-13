import React from 'react';
import { TodoListItem } from './TodoListItem';
import './TodoList.css';

interface Props {
  todos: Todo[];
  toggleTodo: ToggleTodo;
}

export const TodoList: React.FC<Props> = ({ todos, toggleTodo }) => {
  return (
    <ul className="list--unstyled">
      {todos.map((todo) => (
        <TodoListItem key={todo.task} todo={todo} toggleTodo={toggleTodo} />
      ))}
    </ul>
  );
};