   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.SearchTraineeWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  SearchTraineeWindow��5   	   $	��450��6%   $	��800��62   .��5	      � .+�5
   
   �  � ShowGridLines . .+�5      �� -   5         ��Name$ SearchTraineeXml��5      $��Search a Trainee��6.   $��45(�6I   $��Italic$�6W   
���  ��$
��Bold"�6   $��Center=�6�   $��Center=�6�   5      �� 5   
   -   5         ��Name$ searchTraineeBtn��5      $��Search��6+   
�������$
��Bold"�6P   $��26(�6b   $
��Left=�6p   $��140,259,0,0q�6�   $��1��6�   $	��Top=�6�   $	��148��6�   $��46��6�   �� 5   
   -   5         ��Name$ SearchTraineeId_textBox��5      $��1��63   $
��Left=�6C   $��35��6^   $��	38,25,0,0q�6j   $��1��6}    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��253��6  ��6�   �� *id+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6O  �� 5   
   -   5        $ SearchTraineeId��5      $��Enter an ID:��6)   $��1��6@   $��Center=�6P   $��30(�6m   $
��Bold"�6{   $��Center=�6�   $��63��6�   $	��253��6�   $��
38,42,26,0q�6�   	 � ColumnDefinitions	 5   
   �� 5      $	��60* �6   �� 5      $	��40* �6   
 � RowDefinitions
 5   
   �� 5      $	��25* �6   �� 5      $	��75* �6   ��5   
   �� 5       �� ImageSource$: 4images/תמונה רכב אדום לפרויקט.jpg��6    j� Stretch$ UniformToFill=�6I   5      5      