   M S B A M L   `   `   `  ����  TsaregorodtsevLab22    ,TsaregorodtsevLab2.Pages.UpdatePages.UpdDish   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$-  'Редактирование блюда��5      .��5      �� .��5   
   � $��15q�6    � RowDefinitions 5      �� 5	      $
��Auto �6    �� 5
      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $-��'Редактирование блюда��6%   $��18(�6A   $
��Bold"�6O   $��0,0,0,15q�6a   �� 5      -   5         ��Name$ DishesComboBox��5   $   $��1��6    �� DisplayMemberPath$
 Name��6<   $��0,5,0,15q�6U   $��25��6g   �� 5      $��2��6   .+�5      �� $"��Новое название:��6   �� 5      -   5         ��Name$ NameTextBox��5      $��0,5,0,10q�6/   $��25��6A   5      �� 5      $��3��6   .+�5      �� $"��Новое описание:��6   �� 5      -   5        $ DescriptionTextBox��5      $��0,5,0,10q�66   $��60��6H    �� AcceptsReturn$
 True��6T    �� TextWrapping$
 Wrap=�6i   5      �� 5      $��4��6   .+�5       �� $#��Новый тип блюда:��6   �� 5!      -   5        $ DishTypeComboBox��5!      $
 Name��65   $��0,5,0,15q�6N   $��25��6`   5"      �� 5$      -   5         ��Name$ UpdateButton��5$   "   $��5��6   $��Сохранить��68   $	��120��6L   $��30��6X   $��Right=�6d   $��Bottom=�6�   6�   5%      5&      5'      