import java.net.*;
import java.io.*;

public class UDPServer {
	
	public static void main(String[] args) throws Exception {
	DatagramSocket serverSocket = new DatagramSocket(9876);
	byte[] receiveData = new byte[1024];
	byte[] sendData = new byte[1024];
	while(true)
	{
		DatagramPacket receivePacket = new DatagramPacket(receiveData, receiveData.length);
		serverSocket.receive(receivePacket);
		//Deserialize object
		byte[] buf = receivePacket.getData();
		ObjectInputStream in = new ObjectInputStream(new ByteArrayInputStream(buf));
        Creature sentence = (Creature) in.readObject();
        in.close();
        
		System.out.println("RECEIVED: " + sentence.toString());
		InetAddress IPAddress = receivePacket.getAddress();
		int port = receivePacket.getPort();
		sentence.setName("Bob");
		//serialize
		ByteArrayOutputStream bos = new ByteArrayOutputStream() ;
	    ObjectOutput out = new ObjectOutputStream(bos) ;
	    out.writeObject(sentence);
	    out.close();
	    sendData = bos.toByteArray();
	    /////////////////////////////////////////////////////
		DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, IPAddress, port);
		serverSocket.send(sendPacket);
	}
	}	
}
