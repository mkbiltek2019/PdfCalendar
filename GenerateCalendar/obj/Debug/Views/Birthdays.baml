   M S B A M L   `   `   `  ����K  GGenerateCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:GenerateCalendar.ViewsGenerateCalendar.Views  5      I)clr-namespace:GenerateCalendar.ViewModelsGenerateCalendar.ViewModels  5      &     GenerateCalendar.Views.Birthdays   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:GenerateCalendar.Views     5      @
viewModels)clr-namespace:GenerateCalendar.ViewModels     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Ninteractivity:http://schemas.microsoft.com/expression/2010/interactivity  5        � DataContext  5      -  'GenerateCalendar.ViewModels.vmBirthdays  5   
   .��5      ]� ��. .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   .+�5      �� $��40��60   $��6q�6;    � ToolTip$ Add row��6F   ��6   �� *AddRow+.��5      �� $ 
Horizontal=�6   .+�5      �� $3��-/GenerateCalendar;component/Images/AddRow.png��6   $��16��6S   5      5      �� 5      $��40��6.   $��6q�69   $ Sort birthdays��6D   ��6   �� *Sort+.��5      �� $ 
Horizontal=�6   .+�5      �� $1��+/GenerateCalendar;component/Images/Sort.png��6   $��16��6Q   5      5       5!      &   System.Windows.Controls.DataGrid  5#   
      CanUserAddRows .     CanUserDeleteRows .    AutoGenerateColumns .  $��Bottom=�6�   ��6   �� *	Birthdays+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 400 6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Name+   Header 5(      �� 5)      $ 
Horizontal=�6%   .+�5*      �� $1��+/GenerateCalendar;component/Images/USer.png��6$   $��16��6Y   �� 5+      $
��Name��6$   5,      5.      4  .System.Windows.Controls.DataGridTemplateColumn  51       52      �� 53      $ 
Horizontal=�6%   .+�54      �� $0��*/GenerateCalendar;component/Images/Day.png��6$   $��16��6X   �� 55      $��Birthday��6$   56         CellTemplate 58      �� 59      .R�5:      (  "System.Windows.Controls.DatePicker  $��0q�6}      SelectedDate 6)   �� *
BirthDay+$ TwoWay=�$ PropertyChanged=�.	  (System.Windows.Interactivity.Interaction 	  Triggers 5;   "   /
  )System.Windows.Interactivity.EventTrigger
  5<   &    
  	EventName$ SelectedDateChanged��6A   .  (System.Windows.Interactivity.TriggerBase   Actions. 5=   *   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6L   �� *BirthdayChanged+5>   '   5@      5A      5C      4  .System.Windows.Controls.DataGridCheckBoxColumn  5F      
 6)   �� *Dead+ 5G      �� 5H      $ 
Horizontal=�6%   .+�5I      �� $7��1/GenerateCalendar;component/Images/GraveStone.png��6$   $��16��6_   �� 5J      $
��Dead��6$   5K      5M        5P      
 6)   �� *VIP+$ TwoWay=�$ PropertyChanged=� 5Q      �� 5R      $ 
Horizontal=�6%   .+�5S      �� $1��+/GenerateCalendar;component/Images/Star.png��6$   �� 5T      $	��VIP��6$   5U      5W        5Z      
 6%   �� *Age+ 5[      �� 5\      $ 
Horizontal=�6%   .+�5]      �� $0��*/GenerateCalendar;component/Images/Age.png��6$   �� 5^      $	��Age��6$   5_      5a      5d      5f      5g      