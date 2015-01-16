#include<stdio.h>

int expBit(unsigned char binaryArray[33]);
int calcExp(unsigned char binaryArray[33]);
int specialCase(unsigned char binaryArray[33], double mantiss);
char getHexDigit(int decimalValue);

int main(){
	/*asm {
	.section .data
	output:
	.ascii "The processor Vendor ID is 'xxxxxxxxxxxx'\n"
		.section .text
		.globl _start
	_start:
		movl $0, %eax
		cpuid
		movl $output, %edi
		movl %ebx, 28(%edi)
		movl %edx, 32(%edi)
		movl %ecx, 36(%edi)
		movl $4, %eax
		movl $1, %ebx
		movl $output, %ecx
		movl $42, %edx
		int $0x80
		movl $1, %eax
		movl $0, %ebx
		int $0x80

	}*/
	char hexChar;
	int current = 0;
	int end = 0;
	int special = 0;
	int exponentBits = 0;
	double mant = 0.0;
	int normalized = 0;
	int exponent = 0;
	unsigned char binary[33] = {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','\0'};
    char buf[8];
	int userInput = 0x00000000;
	printf("CS201 - A01p - Clayton Burnett\n");
	int i = 1;
    char *B = (char *)&i;

	if(B[0] == 1){
	//little Endian
		printf("byte order: little-endian \n");
	}
	else{
		if(B[0] == '0'){
		//big Endian
			printf("byte order: big-endian \n");
		}
	}

	while(end == 0){
	//BEGIN LOOPING HERE!!!!!!!!!!!!!!!!!!!!!
	//re-init variables
	hexChar = '0';
	current = 0;
	end = 0;
	special = 0;
	exponentBits = 0;
	mant = 0.0;
	normalized = 0;
	exponent = 0;
	int z = 0;
	for(;z < 32; z++){
		binary[z] = '0';
	}
	int a = 0;
	for(;a < 8; a++){
		buf[a] = '0';
	}
	userInput = 0x00000000;
	i = 1;


	//////////////////////////////////////////////////////////////
	printf("> ");
	scanf("%xl",&userInput); //inputting
	printf("0x%08x", userInput);
	//convert the representation to a char array
    sprintf(buf,"%08x",userInput);
	//Then to binary array
	int j = 0;
	for(; j < 8; j++){
		switch(buf[j]){
			case'f':
				//start at j*4 end at j*4 + 4
			//1111
				binary[(j*4)] = '1';
				binary[(j*4)+1] = '1';
				binary[(j*4)+2] = '1';
				binary[(j*4)+3] = '1';
				break;
			case'e':
				binary[(j*4)] = '1';
				binary[(j*4)+1] = '1';
				binary[(j*4)+2] = '1';
				binary[(j*4)+3] = '0';
				//1110
				break;
			case'd':
				binary[(j*4)] = '1';
				binary[(j*4)+1] = '1';
				binary[(j*4)+2] = '0';
				binary[(j*4)+3] = '1';
				//1101
				break;
			case'c':
				binary[(j*4)] = '1';
				binary[(j*4)+1] = '1';
				binary[(j*4)+2] = '0';
				binary[(j*4)+3] = '0';
				//1100
				break;
			case'b':
				binary[(j*4)] = '1';
				binary[(j*4)+1] = '0';
				binary[(j*4)+2] = '1';
				binary[(j*4)+3] = '1';
				//1011
				break;
			case'a':
				binary[(j*4)] = '1';
				binary[(j*4)+1] = '0';
				binary[(j*4)+2] = '1';
				binary[(j*4)+3] = '0';
				//1010
				break;
			case'9':
				binary[(j*4)] = '1';
				binary[(j*4)+1] = '0';
				binary[(j*4)+2] = '0';
				binary[(j*4)+3] = '1';
				//1001
				break;
			case'8':
				binary[(j*4)] = '1';
				binary[(j*4)+1] = '0';
				binary[(j*4)+2] = '0';
				binary[(j*4)+3] = '0';
				//1000
				break;
			case'7':
				binary[(j*4)] = '0';
				binary[(j*4)+1] = '1';
				binary[(j*4)+2] = '1';
				binary[(j*4)+3] = '1';
				//0111
				break;
			case'6':
				binary[(j*4)] = '0';
				binary[(j*4)+1] = '1';
				binary[(j*4)+2] = '1';
				binary[(j*4)+3] = '0';
				//0110
				break;
			case'5':
				binary[(j*4)] = '0';
				binary[(j*4)+1] = '1';
				binary[(j*4)+2] = '0';
				binary[(j*4)+3] = '1';
				//0101
				break;
			case'4':
				binary[(j*4)] = '0';
				binary[(j*4)+1] = '1';
				binary[(j*4)+2] = '0';
				binary[(j*4)+3] = '0';
				//0100
				break;
			case'3':
				binary[(j*4)] = '0';
				binary[(j*4)+1] = '0';
				binary[(j*4)+2] = '1';
				binary[(j*4)+3] = '1';
				//0011
				break;
			case'2':
				binary[(j*4)] = '0';
				binary[(j*4)+1] = '0';
				binary[(j*4)+2] = '1';
				binary[(j*4)+3] = '0';
				//0010
				break;
			case'1':
				binary[(j*4)] = '0';
				binary[(j*4)+1] = '0';
				binary[(j*4)+2] = '0';
				binary[(j*4)+3] = '1';
				//0001
				break;
			default:
				binary[(j*4)] = '0';
				binary[(j*4)+1] = '0';
				binary[(j*4)+2] = '0';
				binary[(j*4)+3] = '0';
				//This is not Hex or it is 0
				break;

		}
	}
	//At this point we have the binary representation stored in binary so..
	exponent = calcExp(binary);
	
	//bits 9-31
	if(exponent != -127){
	//normalized
	normalized = 1;
	mant = 1.0;
	if(binary[9] == '1')
	mant += 0.5;
	if(binary[10] == '1')
	mant += 0.25;
	if(binary[11] == '1')
	mant += 0.125;
	if(binary[12] == '1')
	mant += 0.0625;
	if(binary[13] == '1')
	mant += 0.03125;
	if(binary[14] == '1')
	mant += 0.015625;
	if(binary[15] == '1')
	mant += 0.0078125;
	if(binary[16] == '1')
	mant += 0.00390625;
	if(binary[17] == '1')
	mant += 0.001953125;
	if(binary[18] == '1')
	mant += 0.0009765625;
	if(binary[19] == '1')
	mant += 0.00048828125;
	if(binary[20] == '1')
	mant += 0.000244140625;
	if(binary[21] == '1')
	mant += 0.0001220703125;
	if(binary[22] == '1')
	mant += 0.00006103515625;
	if(binary[23] == '1')
	mant += 0.000030517578125;
	if(binary[24] == '1')
	mant += 0.0000152587890625;
	if(binary[25] == '1')
	mant += 0.00000762939453125;
	if(binary[26] == '1')
	mant += 0.000003814697265625;
	if(binary[27] == '1')
	mant += 0.0000019073486328125;
	if(binary[28] == '1')
	mant += 0.00000095367431640625;
	if(binary[29] == '1')
	mant += 0.000000476837158203125;
	if(binary[30] == '1')
	mant += 0.0000002384185791015625;
	if(binary[31] == '1')
	mant += 0.00000011920928955078125;
	}
	else{
	//denormalized
	normalized = 0;
	mant = 0.0;
	if(binary[9] == '1')
	mant += 1.0;
	if(binary[10] == '1')
	mant += 0.5;
	if(binary[11] == '1')
	mant += 0.25;
	if(binary[12] == '1')
	mant += 0.125;
	if(binary[13] == '1')
	mant += 0.0625;
	if(binary[14] == '1')
	mant += 0.03125;
	if(binary[15] == '1')
	mant += 0.015625;
	if(binary[16] == '1')
	mant += 0.0078125;
	if(binary[17] == '1')
	mant += 0.00390625;
	if(binary[18] == '1')
	mant += 0.001953125;
	if(binary[19] == '1')
	mant += 0.0009765625;
	if(binary[20] == '1')
	mant += 0.00048828125;
	if(binary[21] == '1')
	mant += 0.000244140625;
	if(binary[22] == '1')
	mant += 0.0001220703125;
	if(binary[23] == '1')
	mant += 0.00006103515625;
	if(binary[24] == '1')
	mant += 0.000030517578125;
	if(binary[25] == '1')
	mant += 0.0000152587890625;
	if(binary[26] == '1')
	mant += 0.00000762939453125;
	if(binary[27] == '1')
	mant += 0.000003814697265625;
	if(binary[28] == '1')
	mant += 0.0000019073486328125;
	if(binary[29] == '1')
	mant += 0.00000095367431640625;
	if(binary[30] == '1')
	mant += 0.000000476837158203125;
	if(binary[31] == '1')
	mant += 0.0000002384185791015625;
	}
	exponentBits = expBit(binary);
	special = specialCase(binary, mant);
	//Let's reuse buf
	//clear the buffer
	int b = 0;
	for(;b < 8; b++){
		buf[b] = '0';
	}
	//interested in slots 9-31
	//9th slot counts as 4
	//only use buf 2-7
	if(binary[9] == '1'){
	current += 4;
	}
	if(binary[10] == '1'){
	current += 2;
	}
	if(binary[11] == '1'){
	current += 1;
	}
	buf[2] = getHexDigit(current);
	int h = 12;
	for(;h<32;h+=4){
	current = 0;
		if(binary[h] == '1'){
		current += 8;
		}
		if(binary[h+1] == '1'){
		current += 4;
		}
		if(binary[h+2] == '1'){
		current += 2;
		}
		if(binary[h+3] == '1'){
		current += 1;
		}
	buf[h/4] = getHexDigit(current);
	//3, 4, 5, 6, 7
	//12, 16, 20, 24, 28,  
	}


	printf("\nSignBit %c, expBits %d, fractBits 0x00%c%c%c%c%c%c\n", binary[0], exponentBits, buf[2], buf[3], buf[4], buf[5], buf[6], buf[7]);
	if(special == 0){
		if(normalized == 1){
			printf("normalized:	exp = %d\n", exponent);
		}
		else
		{
			printf("denormalized:  exp = %d\n", exponent);
		}
	}
	else
	{
		//1=+inf 2=-Inf 3=+NaN 4=-NaN
		switch(special){
		case(1):
		printf("+Inf\n");
		break;
		case(2):
		printf("-Inf\n");
		break;
		case(3):
		printf("+NaN\n");
		break;
		case(4):
		printf("-NaN\n");
		break;
		case(5):
		printf("+zero\n");
		end = 1;
		break;
		case(6):
		printf("-zero\n");
		end = 1;
		break;
		default:
		printf("Error\n");
		break;
		}

	}
	printf("\n");

	//Give special case value or normalized/denormalized followed by exp
	//1st bit sign bit, if 0 indicates +1 otherwise -1
	//2-9 exp bit if there is an exponent bit then normalized otherwise denorm
	//10-32 mantisse norm = first bit counts as .5,  denorm = first bit counts as 1
	//# = sign * 2^exponent * mantissa
	/*float number = decimalNumber(binary);
	printf("\n%f", number);*/
	
	
	//END LOOPING HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	}



return(0);
}
//1=+inf 2=-Inf 3=+NaN 4=-NaN 5=+zero 6=-zero
int specialCase(unsigned char binaryArray[33], double mantiss){
int spec = 0;
if(expBit(binaryArray) == 255){
//possible special case
	//all exp no mant  = inf
	//all exp with mant = NaN
	if(binaryArray[0] == '1'){
	//negative
		if(mantiss > 1.0){
		//-NaN
		spec = 4;
		}
		else
		{
		//-Inf
		spec = 2;
		}

	}
	else
	{
	//positive
		if(mantiss > 1.0){
		//NaN
		spec = 3;
		}
		else
		{
		//Inf
		spec = 1;
		}

	}

}
if(expBit(binaryArray) == 0 && mantiss == 0.0){
	if(binaryArray[0] == '1'){
	//negative
		spec = 6;
	}
	else
	{
	//positive
		spec = 5;
	}

}
	return(spec);

}
int expBit(unsigned char binaryArray[33]){
	int px = 0;
	if(binaryArray[8] == '1')
	px += 1;
	if(binaryArray[7] == '1')
	px += 2;
	if(binaryArray[6] == '1')
	px += 4;
	if(binaryArray[5] == '1')
	px += 8;
	if(binaryArray[4] == '1')
	px += 16;
	if(binaryArray[3] == '1')
	px += 32;
	if(binaryArray[2] == '1')
	px += 64;
	if(binaryArray[1] == '1')
	px += 128;
	return(px);

}
int calcExp(unsigned char binaryArray[33]){
	int xp = 0;
	if((binaryArray[1]) == '1'){
	xp = 1;
	}
	else{
	xp = -127;
	}
	if(binaryArray[8] == '1')
	xp += 1;
	if(binaryArray[7] == '1')
	xp += 2;
	if(binaryArray[6] == '1')
	xp += 4;
	if(binaryArray[5] == '1')
	xp += 8;
	if(binaryArray[4] == '1')
	xp += 16;
	if(binaryArray[3] == '1')
	xp += 32;
	if(binaryArray[2] == '1')
	xp += 64;
	return(xp);
}
char getHexDigit(int decimalValue){
	if(decimalValue == 0){
	return('0');
	}
	if(decimalValue == 1){
	return('1');
	}
	if(decimalValue == 2){
	return('2');
	}
	if(decimalValue == 3){
	return('3');
	}
	if(decimalValue == 4){
	return('4');
	}
	if(decimalValue == 5){
	return('5');
	}
	if(decimalValue == 6){
	return('6');
	}
	if(decimalValue == 7){
	return('7');
	}
	if(decimalValue == 8){
	return('8');
	}
	if(decimalValue == 9){
	return('9');
	}
	if(decimalValue == 10){
	return('A');
	}
	if(decimalValue == 11){
	return('B');
	}
	if(decimalValue == 12){
	return('C');
	}
	if(decimalValue == 13){
	return('D');
	}
	if(decimalValue == 14){
	return('E');
	}
	if(decimalValue == 15){
	return('F');
	}
	return('Z');
}
