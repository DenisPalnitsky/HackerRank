
public class Main {

	public static void main(String[] args) {
		
		 
		//System.out.println(root.right.val );

//		Tests.minimal_case();
//		Tests.testHeightsUpdates();		
//		Tests.right_right_case();
//		Tests.right_left_case();
		
		Tests.left_left_case();
		Tests.left_right_case();
		Tests.Case1();
		Tests.Case2();
		Tests.Case2_left();
		
	}
	
	
	
	
		
	
	public static Node insertAndRebalance(int val, Node _root)
    {		
		insertNode ( _root, val);		
		return rebalance(val, _root);		
    }

	private static Node rebalance(int val,  Node _root) {
		
		rebalanceNode (_root, val);
		
		if(BalanceFactor(_root) == -2){
			return rotateRight(_root);
		}
		
		if(BalanceFactor(_root) == 2){
			return rotateLeft(_root);
		}
		
		return _root;
	}

	
	
	private static void rebalanceNode(Node node,  int newVal) {
		
		if (node == null)
			return;
						
		if (newVal > node.val ){			
			rebalanceNode(node.right,   newVal);
			RotateIfNeeded(node);
		}
		else {
			rebalanceNode(node.left, newVal);
			RotateIfNeeded(node);
		}
		
		updateHeight(node);		
		
	}






	private static void RotateIfNeeded(Node node) {
		if ( BalanceFactor(node.right) == -2){					
			node.right =  rotateRight(node.right);	
			updateHeight(node);
			return;
		}
		
		if (BalanceFactor(node.left) == -2 )
			{					
				node.left =  rotateRight(node.left);	
				updateHeight(node);
				return;
			}
		
		if ( BalanceFactor(node.left) == 2){					
			node.left =  rotateLeft(node.left);	
			updateHeight(node);
			return;
		}
		
		if ( BalanceFactor(node.right) == 2){					
			node.right =  rotateLeft(node.right);	
			updateHeight(node);
			return;
		}
	}
	
	



	private static void updateHeight(Node node) {
		if (node.right != null && node.left !=null )
			node.ht = Math.max(node.left.ht, node.right.ht) + 1;
		else if (node.right == null && node.left == null)
			node.ht =0;
		else if (node.left!=null)
			node.ht = node.left.ht+1;
		else if (node.right !=null)
			node.ht = node.right.ht+1;
		else
			throw new Error("Unexpected case");
		
			
		
	}

	private static Node rotateLeft(Node parent) {
		// left right case
		if (BalanceFactor(parent.left) == -1){
			Node tmp = parent.left;
			parent.left = parent.left.right;		
			parent.left.left = tmp;
			tmp.right = null;
			tmp.ht = 0;
			updateHeight(parent.left);
		}
				
		// left left case
		if (BalanceFactor(parent.left) == 1 ){
			Node newParent = parent.left;
						
			Node exRight =  newParent.right;
			newParent.right =  parent;
			parent.left = null;
			
			if (newParent.right == null)
				newParent.right = parent;
			else if (exRight != null)
				insertNode(newParent.right,  exRight);
						
			updateHeight(newParent.right);
			updateHeight(newParent.left);
			updateHeight(newParent);			
						
			return newParent;		
		}
				
		throw new Error();		
	}
	
	private static Node rotateRight(Node parent) {
		
		// right left case
		if (BalanceFactor(parent.right) == 1){
			Node tmp = parent.right;
			parent.right = parent.right.left;		
			parent.right.right = tmp;
			tmp.left = null;
			tmp.ht = 0;
			updateHeight(parent.right);
		}
		
		
		// right right case
		if (BalanceFactor(parent.right) == -1 ){
		Node newParent = parent.right;
				
		Node exLeft =  newParent.left;
		newParent.left =  parent;
		parent.right = null;
		
		if (newParent.left == null)
			newParent.left = parent;
		else if (exLeft != null)
			insertNode(newParent.left,  exLeft);
		
		
		updateHeight(newParent.right);
		updateHeight(newParent.left);
		updateHeight(newParent);
		
		
		return newParent;		
		}
				
		throw new Error();		
	}
	
		

	private static void insertNode(Node parent, Node newNode) {
						
		if (  newNode.val < parent.val){
			if (parent.left == null) {
				parent.left = newNode;
			}			
			else
				insertNode(parent.left, newNode);
		}
		else {
			if (parent.right == null){
				parent.right = newNode;				
			}
			else
				insertNode(parent.right, newNode);
		}
		
		updateHeight(parent);		
	}






	public static Node insertNode(Node node,  int val) {				
		
		Node newNode = null;
		if ( val < node.val ) {			
			if(node.left == null){
				node.left = CreateNode(val, 0, null, null);	
				newNode = node.left; 
			}
			else	{
				newNode = insertNode(node.left,  val);							
			}
			
			updateHeight(node);
		}
		else {
			
			if(node.right == null){
				node.right = CreateNode(val, 0, null, null);
				newNode = node.right;
			}
			else	{
				newNode = insertNode(node.right,  val);														
			}
			
			updateHeight(node);				
		}		
		return newNode;				
	}

		
	public static int BalanceFactor ( Node node ){
		if (node == null)
			return 0;
		
		if( node.left != null && node.right != null)
			return node.left.ht - node.right.ht; 	
		else if (node.left == null && node.right == null)
			return 0;
		else if (node.left == null)
			return 0 - (node.right.ht+1);
		else if (node.right == null)
			return 1 + node.left.ht;	
		
		return 0;		
	}
			
	static Node CreateNode (int value, int height,Node left, Node right){
		Node node = new Node();
		node.ht = height;
		node.val = value;
		node.right = right;
		node.left = left;
		return node;
	}
	
	
	public static void Output(Node node){
		if(node == null)
			return;
		
		Output(node.left);
		System.err.printf("%d(BF=%d, H=%d)  ",  node.val, BalanceFactor(node), node.ht);
		Output(node.right);		
	}
	
	public static void OutputFullTree(Node node){
		if(node == null)
			return;
		
		OutputFullTree(node.left);
		System.err.printf("%d(L=%d, R=%d) ",  node.val, node.left!=null?node.left.val : -1, node.right!=null?node.right.val : -1 );
		OutputFullTree(node.right);		
	}
	
	public static void Output2(Node node){
		
		if(node == null)
			return;
		
		System.err.printf("%d(BF=%d)  ",  node.val, BalanceFactor(node));
		Output2(node.left);		
		Output2(node.right);		
	}

	
	
	static Node insert(Node root, int val)
    {			
       return insertAndRebalance(val, root); 
    }

}
