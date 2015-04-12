PImage source;  // Declare variable "a" of type PImage
PImage destination;
PImage sourceb;
PGraphics pg;
int xscale;
int yscale;

void setup() {
  size(800,800);
  // The image file must be in the data folder of the current sketch 
  // to load successfully
  frameRate(4);
  source = loadImage("20150411174344.png"); 
  source.resize(2048,2048);
  sourceb = loadImage("test2.png"); 
  sourceb.resize(800,800);
  xscale=source.width-width;
  yscale=source.height-width;
    //pg=createGraphics(source.width,source.height,P2D); // LINE WORKS BUT NOT ON CMDLINE
   pg=createGraphics(source.width,source.height, JAVA2D);
print (pg.width);
print (pg.height);

 
destination = createImage(source.width, source.height, RGB);
}

void draw() {
  // Displays the image at its actual size at point (0,0)
  //image(img, 0, 0);
  //background(0, 0, 0);
  background(255,255,255);
  float threshold=127;

  // Build pie chart 1
   pg.beginDraw();
      pg.beginShape();

    //pg.background(255);
    pg.stroke(250 ,80,80);// REDDISH
    pg.stroke(80 ,80,255);
    pg.strokeWeight(140); 
    //pg.fillColor(false);
    pg.noFill();
    //pg.arc(pg.width/2,pg.height/2,2.2*pg.width/3,2.2*pg.height/3,3*PI/2, 2*PI);
    pg.arc(pg.width/2,pg.height/2,2.2*pg.width/3,2.2*pg.height/3,0, 2*PI);
    pg.stroke(255 ,0,0); // RED
    pg.endShape();  
  
    // red edge
    pg.beginShape();
    pg.fill(255,100,100);
    pg.triangle(pg.width,pg.height, 3*pg.height/4,pg.width,pg.width,3*pg.height/4);
    /* pg.triangle(30, 75, 58, 20, 86, 75); */ // Need to fix these lines to get this triangle working
    pg.endShape();
    pg.endDraw();
    pg.updatePixels();
    
  // Displays the image at point (0, height/2) at half of its size
//  image(img, 0, 0, img.width/10, img.height/10);
//  tint(255,0,0);  
  source.loadPixels();
  sourceb.loadPixels();
  int iconwidth=sourceb.width;
  int iconheight=sourceb.height;
  int vertoffset=(source.height-sourceb.height)/2;
  int horizoffset=(source.width-sourceb.width)/2;
/*   print(vertoffset);
print(horizoffset);*/

  destination.loadPixels();

  //for (int s=0;s<30;s++){
   for (int x = 0; x < source.width; x++) {
    for (int y = 0; y < source.height; y++ ) {
      int loc = x + y*source.width;
      // Test the brightness against the threshold
      if (brightness(source.pixels[loc]) > threshold) {
        destination.pixels[loc]  = color(255);  // White
      }  else {
        //RED destination.pixels[loc]  = color(255-x/100-y/100,0-y/100,0-y/100);    // Black
        // GREEN destination.pixels[loc]  = color(100-x/100-y/100,255-y/100,100-y/100);    // Black
        //destination.pixels[loc]  = color(100-x/100-y/100,255-y/100,100-y/100);    // Black
        destination.pixels[loc]  = color(255-x/20-y/20,0-y/20,0-y/20);    // RED
        destination.pixels[loc]  = color(0,0,255-x/10-y/10); //BLUE
        if(brightness(pg.pixels[loc])>127){ 
                  //print( brightness(pg.pixels[loc]));
          //if(brightness(pg.pixels[loc])<250){
           destination.pixels[loc]=pg.pixels[loc]; 
           //print("Doing this");
          //}
        }
        /*if (x<iconwidth) {
           if (y<iconheight){
             int loc2 = (x) + (y)*sourceb.width;
             loc = (x+horizoffset) + (y+vertoffset)*source.width;
             if (brightness(sourceb.pixels[loc2])<200){
               destination.pixels[loc]=sourceb.pixels[loc2];
             }
           }
        }*/
      }
    }
  }
  for (int x = 0; x < source.width-horizoffset*2; x++) {
    for (int y = 0; y < source.height-vertoffset*2; y++ ) {
      int loc = x+horizoffset + (y+vertoffset)*source.width;
      // Test the brightness against the threshold
      if (brightness(source.pixels[loc]) > threshold) {
        //destination.pixels[loc]  = color(255);  // White
      }  else {
        //RED destination.pixels[loc]  = color(255-x/100-y/100,0-y/100,0-y/100);    // Black
        // GREEN destination.pixels[loc]  = color(100-x/100-y/100,255-y/100,100-y/100);    // Black
        //destination.pixels[loc]  = color(100-x/100-y/100,255-y/100,100-y/100);    // Black
        //destination.pixels[loc]  = color(255-x/100-y/100,0-y/100,0-y/100);    // Black
        if (x<iconwidth) {
           if (y<iconheight){
             int loc2 = x + y*sourceb.width;
             if (brightness(sourceb.pixels[loc2])<200){
               if(brightness(sourceb.pixels[loc2])>0){ // fixes java2d issue
                 destination.pixels[loc]=sourceb.pixels[loc2];
               }
             }
           }
        }
      }
    }
  }
      // Display at half opacity      tint(255, 127); 
  destination.updatePixels();
   
     noTint();
  //     image(destination, 0, 0, destination.width*scale, destination.height*scale);
  image(destination, 0, 0, width, height);
  //image(pg, 0, 0, width, height);
  save("/tmp/file.png");


// image(sourceb, 0, 0, sourceb.width/10, sourceb.height/10);  
 //tint(255,255,255,100);
 

  //}
  // We changed the pixels in destination
 
  // Display the destination
  //image(destination,0,0);
}

