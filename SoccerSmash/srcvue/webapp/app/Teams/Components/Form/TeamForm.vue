<template>
  <div class="bg-gray-200">
    <div>
      <form id="form" class=" mx-auto bg-white shadow rounded" method="post" action="/teams" enctype="multipart/form-data">
        <div class="xl:w-full border-b border-gray-300 dark:border-gray-700 py-5">
          <div class="flex items-center w-11/12 mx-auto">
            <p class="text-lg text-gray-800 dark:text-gray-100 font-bold">Team's Information</p>
            <input type="hidden" name="Id">
            <div class="ml-2 cursor-pointer text-gray-600 dark:text-gray-400">
              <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="16" height="16">
                <path class="heroicon-ui" d="M12 22a10 10 0 1 1 0-20 10 10 0 0 1 0 20zm0-2a8 8 0 1 0 0-16 8 8 0 0 0 0 16zm0-9a1 1 0 0 1 1 1v4a1 1 0 0 1-2 0v-4a1 1 0 0 1 1-1zm0-4a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" fill="currentColor" />
              </svg>
            </div>
          </div>
        </div>
        <div class="w-11/12 mx-auto">
          <div class="container mx-auto">
            <div class="my-8 mx-auto xl:w-full xl:mx-0">
              <div class="xl:flex lg:flex md:flex flex-wrap justify-between">
                <div class="xl:w-2/5 lg:w-2/5 md:w-2/5 flex flex-col mb-6">
                  <label for="FirstName" class="pb-2 text-sm font-bold text-gray-800 dark:text-gray-100">Team's Name</label>
                  <input type="text" v-model="teamName" name="Title" required id="FirstName" class="border border-gray-300 dark:border-gray-700 pl-3 py-3 shadow-sm rounded text-sm focus:outline-none bg-transparent focus:border-indigo-700 text-gray-800 dark:text-gray-100" placeholder="" />
                </div>
                <div class="xl:w-2/5 lg:w-2/5 md:w-2/5 flex flex-col mb-6">
                  <label for="Img" class="pb-2 text-sm font-bold text-gray-800 dark:text-gray-100">Team's Logo</label>
                  <div class="h-16 w-16">
                    <img
                         alt="Team's img" ref="imgLoaded" class="h-full w-full rounded-full overflow-hidden shadow" v-if="url" id="imgLoad" :src="url"/>
                </div>
                  <input type='file' name="ImageFile" ref="fileupload" id="ImageFile" @change="onFileChange" /> 
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="w-full py-4 sm:px-12 px-4 bg-gray-100 dark:bg-gray-700 mt-6 flex justify-end rounded-bl rounded-br">
          <button class="btn text-sm focus:outline-none text-gray-600 dark:text-gray-400 border border-gray-300 dark:border-gray-500 py-2 px-6 mr-4 rounded hover:bg-gray-200 transition duration-150 ease-in-out" @click="reset()">Restore</button>
          <button class="modal-close bg-red-700 transition duration-150 ease-in-out hover:bg-indigo-600 rounded text-white px-8 py-2 text-sm focus:outline-none mr-4" type="submit">Cancel</button>
          <button class="bg-indigo-700 transition duration-150 ease-in-out hover:bg-indigo-600 rounded text-white px-8 py-2 text-sm focus:outline-none" type="submit">Save</button>
        </div>
      </form>
    </div>
    
  </div>
</template>
<script src="./TeamForm.ts" lang="ts"></script>