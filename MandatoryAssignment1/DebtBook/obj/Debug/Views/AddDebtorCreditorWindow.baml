   M S B A M L   `   `   `  ����C  ?DebtBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DebtBook.ViewsDebtBook.Views  5   	   9!clr-namespace:DebtBook.ViewModelsDebtBook.ViewModels  5   	   ,    &DebtBook.Views.AddDebtorCreditorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DebtBook.Views     5   	   8
viewModels!clr-namespace:DebtBook.ViewModels     5   	     � Title$  AddDebtorCreditorWindow��5	   	   $	��450��6)   $	��800��66   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��5 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��5 �6   .+�5   
   �� $��1��6   $��1��6!   $��5q�61   Name:6C   �� 5   
   $��1��6   $��2��6   $��20��6/   $��40��6>   $��5q�6L   ��6W   ��  �� Path$
 Name��� 5   
   $��2��6   $��1��6!   $��5q�61   Intitial value:6M   �� 5   
   $��2��6   $��2��6   $��20��6/   $��40��6>   $��5q�6L   ��6W   �� $ Value��� 5    
   $��3��6   $��1��6!   $��5q�61   Intitial desc:6L   �� 5!   
   $��3��6   $��2��6   $��20��6/   $��40��6>   $��5q�6L   ��6W   �� $
 Desc��� 5#   
   -   5        $	��Add��5$      $��4��5%      $��1��5&      $��5q�5'      ��5(      �� *AddButtonCommand+.��62   Add5)      �� 5+   
   -   5        $��Cancel��5,      $��4��5-      $��2��5.      $��5q�5/       �� IsCancel . .��50      Cancel6%   52      53      