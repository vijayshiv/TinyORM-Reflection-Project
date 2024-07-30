# Steps to Run the Project

1. **Clone the Project:**

   - Clone the project repository to your local machine using the following command:
     ```
     git clone https://github.com/vijayshiv/TinyORM-Reflection-Project.git
     ```

2. **Open the Project in Visual Studio:**
   - Launch Visual Studio.
   - Select "Open Project or Solution" from the File menu.
   - Navigate to the cloned project directory and open the `.sln` file.

## Steps to Create the SQL File

1. **Add AttributesLib.dll to POCO Dependencies:**

   - In Visual Studio, right-click on your POCO project in Solution Explorer.
   - Select "Add" -> "Project Reference..."
   - Browse and add the `AttributesLib.dll` from the ORM_Tool project.

2. **Run ORM_Tool.exe:**

   - Build and run the `ORM_Tool.exe` from the ORM_Tool project.
   - When prompted, enter the full path to your POCO DLL. For example:
     ```
     ..\Solution-tiny-orm\TestingPOCO\bin\Debug\net6.0\TestingPOCO.dll
     ```
   - Enter the desired database name when prompted.

3. **Generate SQL Script:**
   - The tool will generate a SQL script based on your POCO library.
   - The SQL script will be saved as `script.sql` in the directory where you ran the `ORM_Tool.exe`.

### Running the Script in the Database Environment

- You can run the generated SQL script (`script.sql`) in your database environment to create the necessary tables and schema.

For any issues or further assistance, please contact [Your Contact Information].

# OR

# ORM_Tool

## Usage Instructions:

1. **Extract the contents** of the `ORM_Tool.zip` file to a directory on your machine.

2. **Ensure Dependencies**: Make sure you also have the `AttributesLib.dll` file in the same directory as `ORM_Tool.exe`. This DLL is necessary for the ORM tool to function properly.

3. **Open a Command Prompt or Terminal window** and navigate to the directory where you extracted the files.

4. **Run the executable** with the following command:

   ```shell
   ORM_Tool.exe
   ```

5. **When prompted**, enter the full path to your POCO library DLL. For example:
   ```shell
   D:\path\to\your\POCO\library\YourLibrary.dll
   ```
6. The tool will generate a SQL script based on the POCO library and save it as **`script.sql`** in the current directory.

7. The SQL script will be created as **script.sql** in the same directory.
