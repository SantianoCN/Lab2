   M S B A M L   `   `   `  ����  TsaregorodtsevLab22    ,TsaregorodtsevLab2.Pages.UpdatePages.UpdMenu   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$+  %Редактирование меню��5      .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $:��4Редактирование позиции меню��6!   $��18(�6D   $
��Bold"�6R   $��0,0,0,15q�6d   �� 5   
   -   5         ��Name$ MenuComboBox��5       $��1��6    �� DisplayMemberPath$ 	Dish.Name��66   $��0,5,0,15q�6T   $��25��6f   �� 5   
   $��2��6   .+�5      �� $��Новая цена:��6   �� 5      -   5         ��Name$ PriceTextBox��5      $��0,5,0,15q�6,   $��25��6>   5      �� 5   
   -   5         ��Name$ UpdateButton��5      $��3��6   $��Сохранить��64   $	��120��6H   $��30��6T   $��Right=�6`   $��Bottom=�6|   6�   5      5      