   M S B A M L   `   `   `  ����M  ITsaregorodtsevLab2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TsaregorodtsevLab2.PagesTsaregorodtsevLab2.Pages  5      '    !TsaregorodtsevLab2.Pages.AuthPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:TsaregorodtsevLab2.Pages     5        N� Title$  Авторизация��5	      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $ ��Вход в систему��5      $��20(�5      $
��Bold"�5      $��Center=�5      $��0,0,0,20q�5      �� 5   
   $��1��6   $��Логин:��5      $��5q�5      �� 5   
   -   5         ��Name$ LoginTextBox��5      $��1��5      $��5,0,5,10q�5       $��25��5!      $��Bottom=�5"      �� 5$   
   $��2��6   $��Пароль:��5%      $��5q�5&      G� 5'   
   -   5         G�Name$ PasswordBox��5(      $��2��5'      $��5,0,5,10q�5)      $��25��5*      $��Bottom=�5+      �� 5-   
   -   5         ��Name$ RememberCheckBox��5.      $��3��5-      $!��Запомнить меня��5/      $��5,5,5,15q�50      �� 52   
   $��4��6    �� Orientation$ 
Horizontal=�53      $��Right=�54      .+�55      �� -   5         ��Name$ LoginButton��55      $��
Войти��56      $	��100��57      $��30��58      $��5,0,5,0q�59      ���	#FF7CA9506<   �� 5:      -   5        $ CancelButton��5:      $��Отмена��5;      $	��100��5<      $��30��5=      $��5,0,5,0q�5>      ���	#FFBB411D6=   5?      5@      5A      