import java.io.*;
import java.net.*;

public class UDPClient {
	public static void main(String args[]) throws Exception
	   {
	      DatagramSocket clientSocket = new DatagramSocket();
	      InetAddress IPAddress = InetAddress.getByName(args[0]);
	      byte[] sendData = new byte[1024];
	      byte[] receiveData = new byte[1024];
	      Creature sentence = new Creature();
	      //Serialize the object
	      //Serialize to byte array
	      ByteArrayOutputStream bos = new ByteArrayOutputStream() ;
	      ObjectOutput out = new ObjectOutputStream(bos) ;
	      out.writeObject(sentence);
	      out.close();
	      sendData = bos.toByteArray();
	      /////////////////////////////////////////
	      DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, IPAddress, 9876);
	      clientSocket.send(sendPacket);
	      //Server confirmation
	      DatagramPacket receivePacket = new DatagramPacket(receiveData, receiveData.length);
	      clientSocket.receive(receivePacket);
	      String modifiedSentence = new String(receivePacket.getData());
	      System.out.println("FROM SERVER:" + modifiedSentence);
	      clientSocket.close();
	   }
}
