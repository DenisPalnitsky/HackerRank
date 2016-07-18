
public class Tests {

	static Node insert(Node root, int val)
    {
		
       return Main.insertAndRebalance(val, root); 
    }
	
	
	public static void left_right_case() {
		Node root = new Node(7, 2, 
				new Node (5, 1, 
							 new Node(3,0, null, null ), null  ),
				new Node(8 , 0, null, null) 
				);
		
		Node newRoot = insert(root, 4 );
				
		if (newRoot.val == 7 &&
				newRoot.left.val == 4  && 
				newRoot.left.left.val == 3 &&
				newRoot.left.right.val == 5 &&
				newRoot.right.val == 8)
				 System.out.println("Good!");
		else
			throw new Error("left_right_case failed");	
	}

	public static void left_left_case() {
		Node root = new Node(5, 2, 
				new Node (4, 1, 
							new Node(3, 0, null, null ), null  ),
				new Node(6 , 0, null, null) 
				);
		
		Node newRoot = insert(root, 2 );
				
		if (newRoot.val == 5 &&
				newRoot.left.val == 3  && 
				newRoot.left.left.val == 2 &&
				newRoot.left.right.val == 4 &&
				newRoot.right.val == 6)
				 System.out.println("Good!");
		else
			throw new Error("left_left_case failed");	
	}

	public static void right_left_case() {
		Node root = new Node(2, 2, 
				new Node (1, 0, null, null  ),
				new Node(3 , 1, null,  
						new Node (5, 0 , null, null )) 
				);
		
		Node newRoot = insert(root, 4 );
		
		
		if (newRoot.val == 2 &&
				newRoot.left.val == 1  && 
				newRoot.right.val == 4 &&
				newRoot.right.left.val == 3 &&
				newRoot.right.right.val == 5)
				 System.out.println("Good!");
		else
			throw new Error("right_left_case failed");		
	}

	public static void replace(Node right) {
		right = new Node(100,2,null,null);
		
	}

	public static void right_right_case() {
		Node root = new Node(3, 2, 
				new Node (2, 0, null, null  ),
				new Node(4 , 1, null,  
						new Node (5, 0 , null, null )) 
				);
		
		Node newRoot = insert(root, 6 );
		//newRoot = insert(root, 1 );
		//newRoot = insert(root, 7 );
		
		if (newRoot.val == 3 &&
				newRoot.left.val == 2  && 
				newRoot.right.val == 5 &&
				newRoot.right.left.val == 4 &&
				newRoot.right.right.val == 6)
				 System.out.println("Good!");
		else
			throw new Error("case1 failed");
		
		if (newRoot.ht != 2)
			throw new Error("case1 Height issue");
	}
	
	public static void minimal_case() {
		Node root = new Node(3, 1, 	
				null,
				new Node(4 , 0, null, null)				 
				);
		
		Node newRoot = insert(root, 6 );
		
		
		if (newRoot.val == 4  && 
				newRoot.right.val == 6 &&
				newRoot.left.val == 3)
				 System.out.println("Good!");
		else
			throw new Error("minimal_case failed");
		
	}
	
	public static void testHeightsUpdates() {				
		Node root = new Node(3, 2, 
				new Node (2, 0, null, null),
				new Node(4 , 1, null,  
						new Node (5, 0 , null, null )) 
				);
		
		
		Main.insertNode(root, 6 );
		Node newRoot =  root;
		
		if (newRoot.ht == 3  && 
				newRoot.right.ht == 2 &&
				newRoot.right.right.ht == 1 &&
				newRoot.right.right.right.ht == 0 &&
				newRoot.left.ht == 0)
				 System.out.println("Good!");
		else
			throw new Error("testHeightsUpdates failed");
		
	}

	public static Node BuildTree(String str){
		String[] n =  str.split(" ");
		Node root = null;
		
		for (int i=0;i<n.length;i++){
			int v =  Integer.parseInt(n[i]);
			
			if(root == null){
				root = new Node();
				root.ht = 0;
				root.val = v;
				continue;
			}
			
			root = Main.insertAndRebalance(v, root);
						
		}
		
		return root;
	}

	public static void Case2() {
		//Node root = BuildTree("14 25 21 10 23 7 26 12 30 16");
		Node root = new Node(21, 3, 
						new Node(10, 2, 
								new Node(7,0,null, null),
								new Node(14,1,
										   new Node(12,0,null, null),
										   new Node(16,0, null, null))),
						new Node(25,2, new Node(23,0,null,null),
								       new Node(26,1,null, new Node(30,0,null,null))));
				
							
			
		
		
	//	System.err.println("");
		Node res = Main.insert(root, 19);
		
//		Main.OutputFullTree(root);
		//System.err.println();
		
		//Main.Output(res);
		//System.err.println();
		//Main.Output2(res);
		
		if(res.val != 21 ||
				res.left.val != 14 ||
				res.left.left.val != 10 ||
				res.left.left.left.val != 7 ||
				res.left.left.right.val != 12)
			throw new Error();
	}
	
	public static void Case2_left() {
		
		Node root = new Node(21, 3, 
						new Node(17, 2, 
								new Node(14,1,
										   new Node(12,0,null, null),
										   new Node(16,0, null, null)),
								new Node(45,0,null, null)
								),
						new Node(25,2, new Node(23,0,null,null),
								       new Node(26,1,null, new Node(30,0,null,null))));
				
							
			
		
		
	//	System.err.println("");
		Node res = Main.insert(root, 19);
		
		Main.OutputFullTree(root);
		//System.err.println();
		
		//Main.Output(res);
		System.err.println();
		Main.Output2(res);
		
		if(res.val != 21 ||
				res.left.val != 16 ||
				res.left.left.val != 14 ||
				res.left.left.left.val != 12 ||
				res.left.right.val != 17 ||
				res.left.right.left.val != 45 ||
				res.left.right.left.left.val != 19 
				)
			throw new Error();
	}
	

	public static void Case1() {
		
		Node root = BuildTree("3 2 4 5");
		Main.Output(root);
		System.out.println("");
		Node res = Main.insert(root, 6);
		Main.Output(res);
		System.out.println();
		Main.Output2(res);
		
	}
	

}
