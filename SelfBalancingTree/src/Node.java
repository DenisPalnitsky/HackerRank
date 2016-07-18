
public class Node {
	   int val;   //Value
       int ht;      //Height
       Node left;   //Left child
       Node right;   //Right child
       
       public Node(int value, int height,Node left, Node right){
    	   val = value;
    	   ht = height;
    	   this.left = left;
    	   this.right = right;
       }
       
       public Node(){}
}
