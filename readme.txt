������ ������� ������������ �����
����� �������� �� �������� ��������

������� ������ 31-07-2016


����� �������:

1. ��������� ������. ����������� ������������ ������� (Queue) � �������������� ����������� ������������ �������. 
������������� ������������ ������ ������������ �������� ���:
  
class ListNode<T> {
           public readonly T Value;
           public readonly ListNode<T> Next;
�}

2. ���� ������:
class TreeNode<T> {  public readonly List<T> Children = new List<T>();}

�������� �������:
IEnumerable<T> WalkInDepth(this TreeNode<T> tree);
IEnumerable<T> WalkInBreadth(this TreeNode<T> tree);

��� ������ ������ � ������� � ������ ��������������.

3. � ����� �������������� � ������� ��� ����� ������� � ����� ������� ����������. 
����� ������� �� ���� �������� N ��� ��������, ��� ������ �������� � ���� ���������� ����� ������� ����������, � ������ �������� - ����� ��� �����. 
���������� �������� ������� ��� ���������� ���������� �������, � ������� �������� � ����� ������������ ���������� ������������ ����� �����������.

��� ������� ����� ����������� unit-�������. 
��� ����������� ���������� ���������� ��������� ����� ���� ���: "������������ ��������� ������", "������", "IEnumerable", "yield return", "extension methods".
������� ����������� �� �� C# ��� F#. 
���������� ������� ������ � .NET Fiddle, CodingGround  ��� ������ ������-����������� � �������� ��� ������,
 ���� �� ������ ������� ����� ������ ������ ��� ������� ����� (�� ���� ����������).

