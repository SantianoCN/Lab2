   M S B A M L   `   `   `  ����  TsaregorodtsevLab2%    TsaregorodtsevLab2.Pages.CrDish   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$!  Создание блюда��5      .��5      �� .��5   
   � $��15q�6    � RowDefinitions 5      �� 5	      $
��Auto �6    �� 5
      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $.��(Создание нового блюда��6%   $��18(�6B   $
��Bold"�6P   $��0,0,0,15q�6b   �� 5      $��1��6   $"��Название блюда:��6!   �� 5      -   5         ��Name$ NameTextBox��5   #   $��2��6   $��0,5,0,10q�68   $��25��6J   �� 5      $��3��6   $��Описание:��6!   �� 5      -   5        $ DescriptionTextBox��5   #   $��4��6   $��0,5,0,10q�6?   $��60��6Q    �� AcceptsReturn$
 True��6]    �� TextWrapping$
 Wrap=�6r   �� 5      $��5��6   $��Тип блюда:��6!   �� 5      -   5         ��Name$ DishTypeComboBox��5   $   $��6��6   $��0,5,0,10q�6>   $��25��6P    �� DisplayMemberPath$
 Name��6\   �� 5!      $��7��6   $��Калории:��6!   �� 5"      -   5        $ CaloriesTextBox��5"   #   $��8��6   $��0,5,0,15q�6<   $��25��6N   �� 5$      -   5         ��Name$ CreateButton��5$   "   $��9��6   $��Создать��68   $	��120��6J   $��30��6V   $��Right=�6b   6~   5%      5&      5'      