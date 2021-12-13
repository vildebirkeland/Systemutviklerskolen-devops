interface Todo {
  id: string;
  task: string;
  complete: boolean;
}

type ToggleTodo = (selectedTodo: Todo) => void;

type AddTodo = (task: string) => void;