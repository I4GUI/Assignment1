   M S B A M L   `   `   `  ����C  ?DebtBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DebtBook.ViewsDebtBook.Views  5   	   0    *DebtBook.Views.InspectDebtorCreditorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DebtBook.Views     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   S OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59,interactivityhttp://prismlibrary.com/  5   	     � Title$!  InspectDebtorCreditorWindow��5
   	   $	��450��6-   $	��800��6:   .��5      �  � ColumnDefinitions 5   
   �� 5      $��5 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��2��6   $��1��6!   $��5q�6.    �� IsCancel . .��6I   Cancel6Q   &   System.Windows.Controls.DataGrid  5   
   $��2��6N   $��3��6[   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5!      $��2��5"      $��5q�5#      ��5      ��  �� Path$" InspectedDebtor.DebitEntries� �� SelectedItem 5      �� $ CurrentDebtor� �� SelectedIndex 5       �� $ CurrentIndex�5%      �� 5'   
   $��2��6   $��3��6$   $��5q�61   Value:6D   �� 5(   
   $��2��6   $��4��6$   $��5q�61   Desc:6C   �� 5*   
   $��3��6   $��3��6"   $��5q�6/   ��6:   �� $ Value�6X   �� 5+   
   $��3��6   $��4��6"   $��5q�6/   ��6:   �� $
 Desc�6W   �� 5-   
   $��4��6   $��3��6!   $��5q�6.   $��2��69   ��6J   �� $ AddDebt�.��6k   
Add Debt6u   5.      5/      