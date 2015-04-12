PImage source;  // Declare variable "a" of type PImage
PImage destination;

void setup() {
  size(490,490);
  // The image file must be in the data folder of the current sketch 
  // to load successfully
  frameRate(4);
  source = loadImage("20150411174344.png");  // Load the image into the program  
destination = createImage(source.width, source.height, RGB);
}

void draw() {
  // Displays the image at its actual size at point (0,0)
  //image(img, 0, 0);
  background(0, 0, 0);
  float threshold=127;

  // Displays the image at point (0, height/2) at half of its size
//  image(img, 0, 0, img.width/10, img.height/10);
//  tint(255,0,0);  
  source.loadPixels();
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
        destination.pixels[loc]  = color(100-x/100-y/100,255-y/100,100-y/100);    // Black

      }
    }
  }
  destination.updatePixels();
     image(destination, 0, 0, destination.width/10, destination.height/10);

  //}
  // We changed the pixels in destination
 
  // Display the destination
  //image(destination,0,0);
}

