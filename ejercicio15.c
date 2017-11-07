/*
15. Write a program that asks for 1 number to the user and show its binary
equivalent value. You can show the binary in inverted order.
*/

#include <stdio.h>

int main()
{
    int decimal = 0;
    int binario = 0;
    int residuo = 0;
    int i = 1;
    
    
    printf("Introduce un numero: ");
    scanf("%i", &decimal);
    
    while(decimal > 1)
    {
        residuo = decimal % 2 ;
        
        binario += residuo * i;
        i *= 10;
        
        decimal = decimal / 2;
    }
    binario += decimal * i;
    
    printf("%i", binario);
    getchar();
    
    return 0;
}