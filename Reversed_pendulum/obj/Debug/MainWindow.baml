   M S B A M L   `   `   `  ����L  HReversed_pendulum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:KWFWMMMProjectKWFWMMMProject  5   	       KWFWMMMProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:KWFWMMMProject     5   	     � Title$  Reversed_pendulum��5   	   $	��600��6#   $
��1000��60   $	��600��6=   $
��1000��6M   .��5	      � -   5         �Name$
 Main��5	      $��Stretch=�6   $��Stretch=�67   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W   .��5      �  � Color$ Black��6    � Offset$ 1Q�6-   � 5      $ 	#FFEEF9FF��6   5      .+�5   
   �� -   5         ��Name$ angle��5      $
��Left=�6!   $��25��6<    �� TextWrapping$
 Wrap=�6H   $	��Top=�6\   $��75��6t   �� 5   
   -   5        $ angular_speed��5      $
��Left=�6)   $��25��6D   $
 Wrap=�6P   $	��Top=�6d   $��75��6|   $��0,25,0,0q�6�   �� 5   
   -   5        $
 mass��5      $
��Left=�6    $��25��6;   $
 Wrap=�6G   $	��Top=�6[   $��75��6s   $��0,50,0,0q�6~   �� 5   
   -   5        $ lenght��5      $
��Left=�6"   $��25��6=   $
 Wrap=�6I   $	��Top=�6]   $��75��6u   $��0,75,0,0q�6�   �� 5   
   -   5        $ friction��5      $
��Left=�6$   $��25��6?   $
 Wrap=�6K   $	��Top=�6_   $��75��6w   $��	0,100,0,0q�6�   	� 5   
   -   5        	 	�Name$	 Square��5      $��square��6&   $
��Left=�67   $	��Top=�6R   $��60��6j   $��	0,135,0,0q�6u   $��20��6�   $��2,1,1,1q�6�   	� 5   
   -   5        $	 Triangle��5      $��triangle��6(   $
��Left=�6;   $	��Top=�6V   $��65��6n   $��
65,135,0,0q�6y   $��20��6�   $��2,1,1,1q�6�   	� 5   
   -	   5        $	 Harmonic��5      $��harmonic��6(   $
��Left=�6;   $	��Top=�6V   $��72��6n   $��130,135,0,0q�6y   $��20��6�   $��2,1,1,1q�6�   �� 5   
   -
   5        $ 
constant_t��5      $
��Left=�6&   $��25��6A   $
 Wrap=�6M   $	��Top=�6a   $��75��6y   $��	0,166,0,0q�6�   �� 5   
   -   5        $ 	amplitude��5      $
��Left=�6%   $��25��6@   $
 Wrap=�6L   $	��Top=�6`   $��75��6x   $��	0,191,0,0q�6�   �� 5   
   -   5        $ period��5      $
��Left=�6"   $��26��6=   $
 Wrap=�6I   $	��Top=�6]   $��75��6u   $��	0,216,0,0q�6�   �� 5   
   -   5        $ fill_factor��5      $
��Left=�6'   $��24��6B   $
 Wrap=�6N   $	��Top=�6b   $��75��6z   $��	0,242,0,0q�6�   �� 5   
   -   5        $ phase_shift��5      $
��Left=�6'   $��25��6B   $
 Wrap=�6N   $	��Top=�6b   $��75��6z   $��	0,266,0,0q�6�   �� 5   
   -   5        $ duration_of_signal��5      $
��Left=�6.   $��25��6I   $
 Wrap=�6U   $	��Top=�6i   $��75��6�   $��	0,291,0,0q�6�   �� 5   
   -   5        $ step_of_time��5      $
��Left=�6(   $��25��6C   $
 Wrap=�6O   $	��Top=�6c   $��75��6{   $��	0,316,0,0q�6�   �� 5   
   -   5        $ freq_of_simulation��5      $
��Left=�6.   $��22��6I   $
 Wrap=�6U   $	��Top=�6i   $��75��6�   $��	0,341,0,0q�6�   �� 5    
   $��ω [°]��6   $
��Left=�6    $	��Top=�6;   $��75,0,0,0q�6S   $��25��6e   $��35��6q   �� 5!   
   $��
ω' [°/s]��6   $
��Left=�6#   $	��Top=�6>   $��	75,25,0,0q�6V   $��25��6i   $��51��6u   �� 5"   
   $��m [kg]��6   $
��Left=�6!   $	��Top=�6<   $��	75,49,0,0q�6T   $��26��6g   $��50��6s   �� 5#   
   $��L [m]��6   $
��Left=�6    $	��Top=�6;   $��	75,75,0,0q�6S   $��25��6f   $��46��6r   �� 5$   
   $��b��6   $
��Left=�6   $	��Top=�67   $��
75,100,0,0q�6O   $��25��6c   $��20��6o   �� 5%   
   $	��Cτ��6   $
��Left=�6   $	��Top=�68   $��
75,166,0,0q�6P   $��25��6d   $��55��6p   �� 5&   
   $��	amplitude��6   $
��Left=�6$   $	��Top=�6?   $��
75,191,0,0q�6W   $��25��6k   �� 5'   
   $��
period [s]��6   $
��Left=�6%   $	��Top=�6@   $��
75,217,0,0q�6X   $��25��6l   �� 5(   
   $��fill [%]��6   $
��Left=�6#   $	��Top=�6>   $��
75,241,0,0q�6V   $��25��6j   $��47��6v   �� 5)   
   $��φ [°]��6   $
��Left=�6    $	��Top=�6;   $��
75,267,0,0q�6S   $��24��6g   $��34��6s   �� 5*   
   $��duration [s]��6   $
��Left=�6'   $	��Top=�6B   $��
75,292,0,0q�6Z   $��24��6n   $��70��6z   �� 5+   
   $��Δt [s]��6   $
��Left=�6!   $	��Top=�6<   $��
75,317,0,0q�6T   $��24��6h   $��65��6t   �� 5,   
   $��simulation freq [Hz]��6   $
��Left=�6/   $	��Top=�6J   $��
75,337,0,0q�6b   $��26��6v   $	��115��6�   �� 5-   
   $��iterations [n]��6   $
��Left=�6)   $	��Top=�6D   $��
75,359,0,0q�6\   $��26��6p   $��80��6|   �� 5.   
   -   5        $ 
iterations��5.      $
��Left=�6&   $��22��6A   $
 Wrap=�6M   $	��Top=�6a   $��75��6y   $��	0,363,0,0q�6�   �� 5/   
   -   5        
 ��Name$
 accept��5/      $��C��6!   $	��Top=�6-   $��346,300,492,0q�6E   $��70��6k   $��	Wingdings)�6w   $��72(�6�   $��1q�6�   ���	#FFDE4B4B
���   �6�   �� 50   
   -   5        $

 Stop��50      $��C��6   $	��Top=�6+   $��492,300,346,0q�6C   $��70��6m   $��	Wingdings)�6y   $��72(�6�   $��1q�6�   ���	#FF514242
���   � J� RenderTransformOrigin$ 0.5,0.5&�6�   z�51      V� 52      .~�53      �� �� 54      �� 55       �� Angle$	 180Q�6&   T� 56      57      59      �� 5:   
   -   5         ��Name$ MyRect��5:      
�������$	��300��61   
���   �$	��Top=�6M   $��346,0q�6e   $��3��6t   �� 5;   
   $��	Iteration��6   $
��Left=�6$   $	��Top=�6?   $��	835,0,0,0q�6W   $��50��6j   $	��155��6v   $��36(�6�   �� 5<   
   $��Moment of time [s]��6   $
��Left=�6-   $	��Top=�6H   $��835,105,0,0q�6`   $	��155��6u   $��35��6�   $��16(�6�   �� 5=   
   -   5         ��Name$ Iteration_counter��5=      $�� ��6+   $
��Left=�66   $	��Top=�6Q   $��
835,50,0,0q�6i   $��55��6}   $	��155��6�   
���   �$��36(�6�   
���  ��$��Malgun Gothic Semilight)�6�   $
��Bold"�6�   $��RightToLeft=�6�   �� 5>   
   -   5        $ Moment_of_time_counter��5>      $�� ��60   $
��Left=�6;   $	��Top=�6V   $��835,140,0,0q�6n   $��55��6�   $	��155��6�   
���   �$��36(�6�   
���  ��$��Malgun Gothic Semilight)�6�   $
��Bold"�6�   $��RightToLeft=�6  5?      5@      