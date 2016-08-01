Данный проект представляет собой
решение тестового задания

Калачев Максим 31-07-2016


Текст задания:


Дано дерево:
class TreeNode<T> {  public readonly List<TreeNode<T>> Children = new List<TreeNode<T>>();}

Написать функции:
IEnumerable<T> WalkInDepth(this TreeNode<T> tree);
IEnumerable<T> WalkInBreadth(this TreeNode<T> tree);

Для обхода дерева в глубину и ширину соответственно.
