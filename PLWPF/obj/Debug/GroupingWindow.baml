   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.GroupingWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  GroupingWindow��5   	   $	��600��6    $
��1000��6-   .��5	      � .+�5
   
   �  � ShowGridLines . .+�5      �� -   5         ��Name$ groupingXml��5      $��Grouping��6)   $��80(�6<   $��Italic$�6J   
���  ��$
��Bold"�6r   $��Center=�6�   $��Center=�6�   $��
14,4,133,6q�6�   $	��448��6�   $	��132��6�   5      �� 5   
   -   5         ��Name$ TraineesByNumOfTestsXml��5      
�������$!��Trainees by Number Of Tests��6J   $��15(�6p   $��1��6~   $��Center=�6�   $��Center=�6�   $	��200��6�   $��50��6�   $��99,32,98,345q�6
  $��1��6   �� 5   
   -   5        $ TraineesBySchoolXml��5      
�������$��Trainees by School��6F   $��20(�6c   $��1��6r   $��1��6�   $��Center=�6�   $��Center=�6�   $	��200��6�   $��50��6�   $��99,126,98,251q�6�   6�   �� 5   
   -   5        $ TraineesByTeacherXml��5      
�������$��Trainees by Teacher��6F   $��20(�6d   $��1��6r   $��1��6�   $��Center=�6�   $��Center=�6�   $	��200��6�   $��50��6�   $��99,216,98,161q�6�   6�   �� 5   
   -   5        $ TestersByProfessionXml��5      
�������$��Testers by Profession��6I   $��20(�6i   $��1��6w   $��Center=�6�   $��Center=�6�   $	��200��6�   $��50��6�   $��97,315,100,62q�6�   $��1��6  �� 5   
   -   5         ��Name$ listView��5      $��20(�6&   $��Center=�65   $
��Bold"�6R   
������ $	��427��6�   $��1��6�   $��Center=�6�   $	��595��6�    �� View 5      �� 5      .P�5      �� $��Grouping by:   ��6%    �� TextAlignment$ Center=�6>    �� Width$	 620��6_   5      5      �� 5   
   -   5         ��Name$ order_checkBox��5      $
��Bold"�6,   $��Ordered��6>   $��1��6P   $��Center=�6�   $��Bottom=�6�   $��24��6�   $��76��6�   	 d� 	IsChecked	 6`   �� *	isOrdered+
 �� Mode$
 TwoWay=�6�    � ColumnDefinitions 5   
   �� 5      $	��60* �6   �� 5      $	��40* �6    � RowDefinitions 5   
   �� 5       $	��25* �6   �� 5!      $	��75* �6   ��5#   
   �� 5$       �� ImageSource$: 4images/תמונה רכב אדום לפרויקט.jpg��6    j� Stretch$ UniformToFill=�6I   5'      5(      