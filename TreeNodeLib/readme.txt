������ ������ ������������ �����
������� ��������� �������

������� ������ 31-07-2016


����� �������:


���� ������:
class TreeNode<T> {  public readonly List<TreeNode<T>> Children = new List<TreeNode<T>>();}

�������� �������:
IEnumerable<T> WalkInDepth(this TreeNode<T> tree);
IEnumerable<T> WalkInBreadth(this TreeNode<T> tree);

��� ������ ������ � ������� � ������ ��������������.
